namespace George_Nikolakeas_PROJECT_B.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal TuitionFee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }



        public Student(string fn, string ln, DateTime dob, decimal tf)
        {
            FirstName = fn;
            LastName = ln;
            DateOfBirth = dob;
            TuitionFee = tf;
        }

        public void SFiller()
        {
            Helper.AskName("first", "student:");
            FirstName = Helper.StringInput();
            Helper.AskName("last", "student:");
            LastName = Helper.StringInput();
            Helper.AskDate("student was born:");
            DateOfBirth = Helper.DateTimeInput();
            while (DateOfBirth.AddYears(18) > DateTime.Now)
            {
                Console.WriteLine("Student cant be less than 18 years old!Type again:");
                DateOfBirth = Helper.DateTimeInput();
            }
            Console.WriteLine("Enter student's tuiton fee:");
            TuitionFee = Helper.TuitFee();
        }

        private bool StudentExists(MegaHard cd)
        {
            bool b = cd.Students.Any(s => s.FirstName == FirstName && s.LastName == LastName && s.DateOfBirth == DateOfBirth);
            return b;
        }

        public void AddStudentToCourse(Student st, MegaHard cd)
        {
            if (!StudentExists(cd))
            {
                try
                {
                    cd.Students.Add(st);
                    cd.SaveChanges();
                    Assign(cd, st);
                }
                catch (SqlException)
                {
                    Console.WriteLine("All ok");
                }

            }
            else
                Console.WriteLine("Student already exists so this instance is deleted!");
        }

        private void Assign(MegaHard cd, Student st)
        {
            List<Course> courselist = cd.Courses.ToList();

            Console.WriteLine("\nAssign Student to course:");
            try
            {
                int input = Helper.Assign("Student", courselist);
                input = ifInputis0(input, courselist, st.StudentID);

                while (input != 0 && courselist.Where(c => c.CourseID == input).Any(c => c.Students.Any(s => s.StudentID == st.StudentID)))
                {
                    Console.WriteLine("\nStudent already exists that course! Choose another:\n");
                    input = Helper.Assign("Student", courselist);
                    input = ifInputis0(input, courselist, st.StudentID);
                    if (input == 0)
                    {
                        break;
                    }
                }
                if (input != 0)
                {
                    try
                    {
                        cd.Courses.FirstOrDefault(c => c.CourseID == input).Students.Add(st);
                        cd.SaveChanges();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                bool assignAgain = Helper.AssignAgain("Student");
                if (assignAgain)
                    Assign(cd, st);
            }
            catch (Exception)
            {
                Console.Beep();
                //Console.WriteLine(ex.Message);
                Console.WriteLine("Good job! You have unlocked a hidden code block! Please restart for secret features!");
            }
        }

        private int ifInputis0(int input, List<Course> courselist, int thisSID)
        {
            while (input == 0 && !StudentIsinaList(courselist, thisSID))
            {
                Console.WriteLine("You must assign student to one Course at least!\n");
                input = Helper.Assign("Student", courselist);
            }
            return input;
        }

        private bool StudentIsinaList(List<Course> courselist, int thisSID)
        {
            bool x = courselist.Any(c => c.Students.Any(s => s.StudentID == thisSID));
            return x;
        }
    }
}
