using George_Nikolakeas_PROJECT_B.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Nikolakeas_PROJECT_B
{
    public static class Menu1
    {
        public static int MenuInputCheck(int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 5)
            {
                Console.WriteLine("Wrong input! Enter a number between 1 and 5:");
            }
            return input;
        }

        public static int MenuDisplay()
        {
            int input = 0;
            Console.WriteLine("\nWhat do you want to do? \n\n[1]-Add Course\n[2]-Add Trainer\n[3]-Add Student\n[4]-Add Assignment\n[5]-Show Data");
            input = MenuInputCheck(input);
            return input;
        }

        public static void Menu1Run(MegaHard cd)
        {
            Console.WriteLine("Welcome to Spaghetti code");
            int input = MenuDisplay();

            while (input != 5)
            {
                if (input == 1)
                {
                    Helper.CreateCourse(cd);
                }
                else if (input == 2)
                {
                    Helper.CreateTrainer(cd);
                }
                else if (input == 3)
                {
                    Helper.CreateStudent(cd);
                }
                else if (input == 4)
                {
                    Helper.CreateAssignment(cd);
                }
                input = MenuDisplay();
            }
        }
    }

}
