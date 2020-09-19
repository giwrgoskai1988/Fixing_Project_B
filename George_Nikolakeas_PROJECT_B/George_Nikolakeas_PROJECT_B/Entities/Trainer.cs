namespace George_Nikolakeas_PROJECT_B.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            Courses = new HashSet<Course>();
        }

        public int TrainerID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }



        public Trainer(string fn, string ln, string sub)
        {
            FirstName = fn;
            LastName = ln;
            Subject = sub;
        }

        public void TFiller()
        {
            Helper.AskName("first", "trainer:");
            FirstName = Helper.StringInput();
            Helper.AskName("last", "trainer");
            LastName = Helper.StringInput();
            Helper.AskName("", "subject");
            Subject = Helper.StringInput();
        }

        private bool TrainerExists(MegaHard cd)
        {
            bool b = cd.Trainers.Any(t => t.FirstName == FirstName && t.LastName == LastName && t.Subject == Subject);
            return b;
        }

        public void AddTrainerToCourse(Trainer tr, MegaHard cd)
        {
            if (!TrainerExists(cd))
            {
                try
                {
                    cd.Trainers.Add(tr);
                    cd.SaveChanges();
                    Assign(cd, tr);
                }
                catch (SqlException)
                {
                    Console.WriteLine("All ok");
                }
            }
            else
                Console.WriteLine("Trainer already exists so this instance is deleted!");
        }

        private void Assign(MegaHard cd, Trainer tr)
        {
            List<Course> courselist = cd.Courses.ToList();
            Console.WriteLine("\nAssign Trainer to course:");
            try
            {
                int input = Helper.Assign("Trainer", courselist);
                input = ifInputis0(input, courselist, tr.TrainerID);

                while (input != 0 && courselist.Where(c => c.CourseID == input).Any(c => c.Trainers.Any(t => t.TrainerID == tr.TrainerID)))
                {
                    Console.WriteLine("\nTrainer already exists that course! Choose another:\n");
                    input = Helper.Assign("Trainer", courselist);
                    input = ifInputis0(input, courselist, tr.TrainerID);
                    if (input == 0)
                    {
                        break;
                    }
                }
                if (input != 0)
                {
                    try
                    {
                        cd.Courses.FirstOrDefault(c => c.CourseID == input).Trainers.Add(tr);
                        cd.SaveChanges();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                bool assignAgain = Helper.AssignAgain("Trainer");
                if (assignAgain)
                    Assign(cd, tr);
            }
            catch (Exception)
            {
                Console.Beep();
                //Console.WriteLine(ex.Message);
                Console.WriteLine("Good job! You have unlocked a hidden code block! Please restart!");
            }
        }

        private int ifInputis0(int input, List<Course> courselist, int thisTID)
        {
            while (input == 0 && !TrainerIsinaList(courselist, thisTID))
            {
                Console.WriteLine("You must assign trainer to one Course at least!\n");
                input = Helper.Assign("Trainer", courselist);
            }
            return input;
        }

        private bool TrainerIsinaList(List<Course> courselist, int thisTID)
        {
            bool x = courselist.Any(c => c.Trainers.Any(t => t.TrainerID == thisTID));
            return x;
        }
    }
}
