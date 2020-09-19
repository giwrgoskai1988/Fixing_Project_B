namespace George_Nikolakeas_PROJECT_B.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Students = new HashSet<Student>();
            Trainers = new HashSet<Trainer>();
        }

        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Stream { get; set; }

        public bool Type { get; set; }

        public DateTime Start_date { get; set; }

        public DateTime End_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }

        public Course(string t, string s, bool tt, DateTime sd, DateTime ed)
        {
            Title = t;
            Stream = s;
            Type = tt;
            Start_date = sd;
            End_date = ed;
        }

        public void CFiller()
        {
            Helper.AskName("", "course:");
            Title = Helper.StringInput();
            Helper.AskName("", "stream:");
            Stream = Helper.StringInput();
            Console.WriteLine("Is it part time or full time?");
            Type = Helper.CheckType();
            try
            {
                Helper.AskDate("course starts:");
                Start_date = Helper.DateTimeInput();

                Helper.AskDate("course ends:");
                if (Type == false)
                {
                    End_date = Helper.DatimeForEndDate(Start_date, End_date, 3);

                }
                else
                {
                    End_date = Helper.DatimeForEndDate(Start_date, End_date, 6);
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Wrong date! please enter a proper date");
            }
        }

        public void AddCourseToList(Course a, MegaHard cd)
        {
            bool b = cd.Courses.Any(c => c.Title == Title && c.Stream == Stream && c.Type == Type && c.Start_date == Start_date && c.End_date == End_date);

            if (!b)
            {
                try
                {
                    cd.Courses.Add(a);
                    cd.SaveChanges();
                }
                catch (SqlException)
                {
                    Console.WriteLine("All ok");
                }
            }
            else
                Console.WriteLine("Course already exists so this instance is deleted!");
        }

    }
}
