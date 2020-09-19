namespace George_Nikolakeas_PROJECT_B.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int AssID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DateTime SubDateTime { get; set; }

        public int OralMark { get; set; }

        public int TotalMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public Assignment(string t, string des, DateTime sdt, int oral, int total)
        {
            Title = t;
            Description = des;
            SubDateTime = sdt;
            OralMark = oral;
            TotalMark = total;
        }
        public void AFiller()
        {
            Helper.AskName("", "assignment:");
            Title = Helper.StringInput();
            Console.WriteLine("Enter the description of assignment:");
            Description = Helper.StringInput();
            Helper.AskDate("assignment must be completed:");
            SubDateTime = Helper.DateTimeInput();
            //while (!IsInCourseDateRange(courselist))
            //{
            //    Console.WriteLine("Assign due date isnt sooner than any course!! Please put a proper date again:");
            //    SubDateTime = Helper.DateTimeInput();
            //}
            Console.WriteLine("Enter assignment's oral mark:");
            OralMark = Helper.OralMark();
            Console.WriteLine("Enter assignment's total mark:");
            TotalMark = Helper.TotalMark(OralMark);
        }


        public void AddAssToCourse(Assignment ass, MegaHard cd)
        {
            bool b = cd.Assignments.Any(a => a.Title == Title && a.Description == Description && a.SubDateTime == SubDateTime && a.OralMark == OralMark && a.TotalMark == TotalMark);

            if (!b)
            {
                try
                {
                    cd.Assignments.Add(ass);
                    cd.SaveChanges();
                    Assign(cd, ass);
                }
                catch (SqlException)
                {
                    Console.WriteLine("All ok");
                }
            }
            else
                Console.WriteLine("Assignment already exists so this instance is deleted!");
        }

        private void Assign(MegaHard cd, Assignment ass)
        {
            List<Course> courselist = cd.Courses.ToList();
            Console.WriteLine("\nAssign Assignment to course:");
            try
            {
                int input = Helper.Assign("Assignment", courselist);
                input = ifInputis0(input, courselist, ass.AssID);

                while (input != 0 && courselist.Where(c => c.CourseID == input).Any(c => c.Assignments.Any(a => a.AssID == ass.AssID)))
                {
                    Console.WriteLine("\nAssignment already exists that course or Assignment Sub Date is sooner than the course Start Date! Choose another:\n");
                    input = Helper.Assign("Assignment", courselist);
                    input = ifInputis0(input, courselist, ass.AssID);

                    if (input == 0)
                    {
                        break;
                    }
                }
                if (input != 0)
                {
                    try
                    {
                        cd.Courses.FirstOrDefault(c => c.CourseID == input).Assignments.Add(ass);
                        cd.SaveChanges();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                bool assignAgain = Helper.AssignAgain("Assignment");
                if (assignAgain)
                    Assign(cd, ass);
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.Message);
                Console.Beep();
                Console.WriteLine("Good job! You have unlocked a hidden code block! Please restart!");
            }
        }

        private int ifInputis0(int input, List<Course> courselist, int thisAssID)
        {
            while (input == 0 && !AssIsinaList(courselist, thisAssID))
            {
                Console.WriteLine("You must assign the Assignment to one Course at least!\n");
                input = Helper.Assign("Assignment", courselist);
            }
            return input;

        }

        private bool AssIsinaList(List<Course> courselist, int thisAssID)
        {
            bool x = courselist.Any(c => c.Assignments.Any(a => a.AssID == thisAssID));
            return x;
        }
    
    }
}
