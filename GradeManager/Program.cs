using System;
using System.Collections.Generic;

namespace GradeManager
{
    class Program
    {
        // Create list to hold grades
        public static List<double> gradesList = new List<double>() {};
        
        static void Main(string[] args)
        {
            // Display title & menu choices
            Console.WriteLine("Welcome to Grade Manager\n");
            Console.WriteLine("Please choose an option below:");
            Console.WriteLine("1. Show Grades\n" + 
                                "2. Add Grade\n" + 
                                "3. Show Class Average\n" + 
                                "4. Show Best Grade\n" +
                                "5. Show Worst Grade\n" +
                                "6. Remove Grade\n" +
                                "7. Edit Grade\n" +
                                "8. Exit Application");
            Console.WriteLine("------------------");

            // Create variable to store user's choice
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            while (true) // Daniel Way helped me with this
            {
                switch (menuChoice)
                {
                    case 1: // --------- SHOW GRADES ---------
                        if (gradesList.Count > 0)
                        {
                            for (int i = 0; i < gradesList.Count; i++)
                            {
                                Console.WriteLine("Student " + i + ": " + gradesList[i]);
                            }
                        } 
                        else
                        {
                            Console.WriteLine("No grades found. Please add a grade.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Add grade as a decimal value or whole value. (ie 34.5)");
                        double newGrade = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("The grade you entered is: " + newGrade);
                        gradesList.Add(newGrade);
                        break;
                    case 8:
                        return;
                    default:
                        break;
                }

                Console.WriteLine("Please choose a valid option between 1-8");
                menuChoice = Convert.ToInt32(Console.ReadLine());
                // ------------ END OF SWITCH ------------
            }


        } // ------------ END OF MAIN ------------


    } // ------------ END OF PROGRAM CLASS ------------
} // ------------ END OF GRADEMANAGER NAMESPACE ------------
