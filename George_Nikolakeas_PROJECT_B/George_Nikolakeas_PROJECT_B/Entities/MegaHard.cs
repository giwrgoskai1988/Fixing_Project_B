namespace George_Nikolakeas_PROJECT_B.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MegaHard : DbContext
    {
        public MegaHard()
            : base("name=MegaHard")
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Assignments)
                .Map(m => m.ToTable("Course_Assignments").MapLeftKey("AssID").MapRightKey("CourseID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("Course_Students").MapLeftKey("CourseID").MapRightKey("StudentID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Trainers)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("Course_Trainers").MapLeftKey("CourseID").MapRightKey("TrainerID"));

            modelBuilder.Entity<Student>()
                .Property(e => e.TuitionFee)
                .HasPrecision(8, 2);
        }
    }
}
