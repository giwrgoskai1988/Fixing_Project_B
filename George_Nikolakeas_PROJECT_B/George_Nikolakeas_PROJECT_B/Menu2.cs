using George_Nikolakeas_PROJECT_B.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Nikolakeas_PROJECT_B
{
    public static class Menu2
    {
        public static int Display()
        {
            int input = 0;

            Console.WriteLine("\nWhat do you want to see?\n");
            Console.WriteLine("[1]-All courses\n[2]-All trainers\n[3]-All students\n[4]-All Assignments\n[5]-Trainers per course\n" +
                              "[6]-Students per course\n[7]-Assignments per course\n" +
                              "[8]-Assignments per student\n[9]-Students that belong to more than one course\n" +
                              "[10]-Exit");

            input = InputCheck(input);
            return input;
        }

        public static int InputCheck(int input)
        {
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 10)
            {
                Console.WriteLine("Wrong input! Enter a number between 1 and 10:");
            }
            return input;
        }

        public static void Menu2Run(List<Course> courselist, List<Trainer> trainerlist, List<Student> studentlist, List<Assignment> asslist)
        {
            int input = Menu2.Display();

            while (input != 10)
            {
                if (input == 1)
                {
                    foreach (Course c in courselist)
                    {
                        Console.WriteLine($"{c.CourseID} -- {c.Title} -- {c.Stream} -- {c.Type} -- {c.Start_date.ToString("yyyy/MM/dd")} --" +
                            $" {c.End_date.ToString("yyyy/MM/dd")} ");
                    }
                }
                if (input == 2)
                {
                    foreach (Trainer t in trainerlist)
                    {
                        Console.WriteLine($"{t.TrainerID} -- {t.FirstName} -- {t.LastName} -- {t.Subject}");
                    }
                }
                if (input == 3)
                {
                    foreach (Student s in studentlist)
                    {
                        Console.WriteLine($"{s.StudentID} -- {s.FirstName} -- {s.LastName} -- {s.DateOfBirth.ToString("yyyy/MM/dd")} -- {s.TuitionFee}");
                    }
                }
                if (input == 4)
                {
                    foreach (Assignment a in asslist)
                    {
                        Console.WriteLine($"{a.AssID} -- {a.Title} -- {a.Description} -- {a.SubDateTime.ToString("yyyy/MM/dd")} -- {a.OralMark} -- {a.TotalMark}");
                    }
                }
                if (input == 5)
                {
                    foreach (Course c in courselist)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("---------------------COURSE------------------");
                        Console.WriteLine($"{c.CourseID} -- {c.Title} -- {c.Stream} -- {c.Type} -- {c.Start_date.ToString("yyyy/MM/dd")} --" +
                            $" {c.End_date.ToString("yyyy/MM/dd")} ");

                        if (c.Trainers.Count > 0)
                        {
                            Console.WriteLine("-------------------TRAINERS------------------");
                            foreach (Trainer t in c.Trainers)
                            {
                                Console.WriteLine($"{t.TrainerID} -- {t.FirstName} -- {t.LastName} -- {t.Subject}");
                            }
                        }
                        else
                            Console.WriteLine("Course HAS NO TRAINERS!!!");
                    }
                }
                if (input == 6)
                {
                    foreach (Course c in courselist)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("---------------------COURSE------------------");
                        Console.WriteLine($"{c.CourseID} -- {c.Title} -- {c.Stream} -- {c.Type} -- {c.Start_date.ToString("yyyy/MM/dd")} --" +
                               $" {c.End_date.ToString("yyyy/MM/dd")} ");

                        if (c.Students.Count > 0)
                        {
                            foreach (Student s in c.Students)
                            {
                                Console.WriteLine("-------------------STUDENTS------------------");
                                Console.WriteLine($"{s.StudentID} -- {s.FirstName} -- {s.LastName} -- {s.DateOfBirth.ToString("yyyy/MM/dd")} -- {s.TuitionFee}");
                            }
                        }
                        else
                            Console.WriteLine("COURSE HAS NO STUDENTS!!!!");
                    }
                }
                if (input == 7)
                {
                    foreach (Course c in courselist)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("---------------------COURSE------------------");
                        Console.WriteLine($"{c.CourseID} -- {c.Title} -- {c.Stream} -- {c.Type} -- {c.Start_date.ToString("yyyy/MM/dd")} --" +
                              $" {c.End_date.ToString("yyyy/MM/dd")} ");

                        if (c.Assignments.Count > 0)
                            foreach (Assignment a in c.Assignments)
                            {
                                Console.WriteLine("-------------------ASSIGNMENTS----------------");
                                Console.WriteLine($"{a.AssID} -- {a.Title} -- {a.Description} -- {a.SubDateTime.ToString("yyyy/MM/dd")} -- {a.OralMark} -- {a.TotalMark}");
                            }
                        else
                            Console.WriteLine("COURSE HAS NO ASSIGNMENTS!!!!");
                    }
                }
                if (input == 8)
                {
                    foreach (Assignment a in asslist)
                    {
                        var crs = a.Courses.Distinct();
                        Console.WriteLine("-------------------ASSIGNMENTS----------------");
                        Console.WriteLine($"{a.AssID} -- {a.Title} -- {a.Description} -- {a.SubDateTime.ToString("yyyy/MM/dd")} -- {a.OralMark} -- {a.TotalMark}");
                        Console.WriteLine("-------------------STUDENTS------------------");
                        foreach (Course c in crs)
                        {
                            foreach(Student s in c.Students)
                            {
                               
                                Console.WriteLine($"{s.StudentID} -- {s.FirstName} -- {s.LastName} -- {s.DateOfBirth.ToString("yyyy/MM/dd")} -- {s.TuitionFee}");
                            }

                        }
                    }
                }

                if (input == 9)
                {
                    Console.WriteLine("These Students belong to more than one Course!");
                    foreach (Student s in studentlist)
                    {
                        if (s.Courses.Count > 1)
                        {
                            Console.WriteLine($"{s.StudentID} -- {s.FirstName} -- {s.LastName} -- {s.DateOfBirth.ToString("yyyy/MM/dd")} -- {s.TuitionFee} " +
                                $"-- Watches {s.Courses.Count} courses!");
                        }
                    }
                }
                input = Menu2.Display();
            }
        }
    }
}
