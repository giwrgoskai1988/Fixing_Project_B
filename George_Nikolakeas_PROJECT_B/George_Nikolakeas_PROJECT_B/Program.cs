using George_Nikolakeas_PROJECT_B.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Nikolakeas_PROJECT_B
{
    class Program
    {
        static void Main(string[] args)
        {
            MegaHard cd = new MegaHard();
            List<Course> courselist = cd.Courses.ToList();
            List<Trainer> trainerlist = cd.Trainers.ToList();
            List<Student> studentlist = cd.Students.ToList();
            List<Assignment> asslist = cd.Assignments.ToList();

            Menu1.Menu1Run(cd);

            // I have to reload everything because for some reason out of menu context lists arent updated but database is.
            courselist = cd.Courses.ToList();
            studentlist = cd.Students.ToList();
            studentlist = cd.Students.ToList();
            asslist = cd.Assignments.ToList();

            Menu2.Menu2Run(courselist, trainerlist, studentlist, asslist);
        }
    }
}
