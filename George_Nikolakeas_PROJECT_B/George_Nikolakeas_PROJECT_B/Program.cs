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
        

            Menu1.Menu1Run(cd);

            var courselist = cd.Courses.ToList();
            var trainerlist = cd.Trainers.ToList();
            var studentlist = cd.Students.ToList();
            var asslist = cd.Assignments.ToList();

            Menu2.Menu2Run(courselist, trainerlist, studentlist, asslist);
        }
    }
}
