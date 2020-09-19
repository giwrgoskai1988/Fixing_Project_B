using George_Nikolakeas_PROJECT_B.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Nikolakeas_PROJECT_B
{
    public static class Helper
    {
        //These create objects
        public static void CreateCourse(MegaHard cd)
        {
            Course a = new Course();
            a.CFiller();
            a.AddCourseToList(a, cd);
        }

        public static void CreateTrainer(MegaHard cd)
        {
            Trainer tr = new Trainer();
            tr.TFiller();
            tr.AddTrainerToCourse(tr, cd);
        }

        public static void CreateStudent(MegaHard cd)
        {
            Student st = new Student();
            st.SFiller();
            st.AddStudentToCourse(st, cd);
        }

        public static void CreateAssignment(MegaHard cd)
        {
            Assignment a = new Assignment();
            a.AFiller();
            a.AddAssToCourse(a, cd);
        }

        //The below method asks if user wants to add Student,Trainer or Assignment to another course 
        public static bool AssignAgain(string a)
        {
            bool y = false;
            Console.WriteLine($"Do you want to assign {a} to another course?(Yes or No)");
            string b = Console.ReadLine();
            while (b.ToLower() != "yes" && b.ToLower() != "no")
            {
                Console.WriteLine("Please type Yes or No:");
                b = Console.ReadLine();
            }
            if (b.ToLower() == "yes")
            {
                y = true;
            }
            return y;
        }

        //The below  method shows all courses and returns the ID of the course the user decided to assign Student,Trainer or Assignment

        public static int Assign(string a, List<Course> courselist)
        {
            int input = 0;

            foreach (Course j in courselist)
            {
                Console.WriteLine($"Press {j.CourseID} to assign to {j.Title} , {j.Stream} , {j.Type} , {j.Start_date.ToString("yyyy/M/d")} , {j.End_date.ToString("yyyy/M/d")} ");
            }
            Console.WriteLine("Or type 0 to go back:");

            while (!int.TryParse(Console.ReadLine(), out input) || !Helper.Validation(input, courselist))
            {
                Console.WriteLine($"Wrong input! Enter the proper Course id you want the {a} to be assigned:");
            }
            return input;
        }

        //this method is called int the above method and checks if user chose the proper course ID (0 goes back to menu)

        public static bool Validation(int input, List<Course> courselist)
        {

            bool y = false;

            if (input == 0 || courselist.Any(c => c.CourseID == input))
            {
                y = true;
            }
            return y;
        }

        // These 2 are for checking obj (ASSIGNMENT type) mark values.
        public static int TotalMark(int b)
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0 || a <= b)
                Console.WriteLine("Wrong input. Please enter a positive integer number higher than oral mark:");
            return a;
        }

        public static int OralMark()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                Console.WriteLine("Wrong input. Please enter a positive integer number:");
            return a;
        }

        //This  checks a value of obj (STUDENT type).
        public static decimal TuitFee()
        {
            decimal a;
            while (!decimal.TryParse(Console.ReadLine(), out a) || a < 0 || a >= 1000000)
            {
                Console.WriteLine("Wrong input! Please type a positive tuition fee:");
            }
            return a;
        }

        //This checks for all string inputs.
        public static string StringInput()
        {
            string input = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(input) || input.Length > 50)
            {
                Console.WriteLine("Field cannot be empty or more than 50 characters.You must enter something in that range:");
                input = Console.ReadLine();
            }
            return input.Trim();
        }

        //These 2 are for Displaying Messages to ask input from user.
        public static void AskName(string b = "", string c = "")
        {
            string a = $"Enter the {b} name of the {c}";
            string result = b != "" ? a = string.Format(a, b, c) : a = string.Format(a, b, c);
            Console.WriteLine(result);
        }

        public static void AskDate(string b = "")
        {
            string a = "Enter the date (Year / Month / Day) when {0}";
            string result = b != "" ? a = string.Format(a, b) : a;
            Console.WriteLine(result);
        }

        //This checks all Datetime inputs.
        public static DateTime DateTimeInput()
        {
            DateTime dt;
            string dtIntput = Console.ReadLine();
            string[] formats = { "yyyy.M.d", "yyyy/M/d", "yyyy-M-d" };
            while (!DateTime.TryParseExact(dtIntput, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) || dt.Year < 1900)
            {
                Console.WriteLine("Wrong input! Please enter a date (Year / Month / Day) or (Year-Month-Day) or (Year.Month.Day)and (Year should be always 4 digits):");
                dtIntput = Console.ReadLine();
            }
            return dt;
        }

        //this checks end date and start date
        public static DateTime DatimeForEndDate(DateTime Start_Date, DateTime End_Date, int x)
        {
            while (DateTime.Compare(Start_Date, End_Date) > 0 || End_Date < Start_Date.AddMonths(x))
            {
                Console.WriteLine($"\nMake sure the end date cant be sooner than {x} months from  the start date:");
                End_Date = Helper.DateTimeInput();
            }
            return End_Date;
        }

        //This checks the value {TYPE} of obj (COURSE type).
        public static bool CheckType()
        {
            string a = Console.ReadLine();
            while (a.Trim().ToLower() != "full time" && a.Trim().ToLower() != "part time")
            {
                Console.WriteLine("Please type (full time) if its full time or (part time) for part time.");
                a = Console.ReadLine();
            }
            a = a.Trim();

            if (a.ToLower() == "part time")
                return false;
            else
                return true;
        }
    }
}
