using System;
using System.Collections.Generic;

namespace GradeManager
{
    class Program
    {
        // Create list to hold grades
        public static List<string> gradesList = new List<string>() {};
        
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

            // Store user's choice into variable
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine("You selected option " + menuChoice);
                    break;
                default:
                    break;
            } // ------------ END OF SWITCH ------------


        } // ------------ END OF MAIN ------------


    } // ------------ END OF PROGRAM CLASS ------------
} // ------------ END OF GRADEMANAGER NAMESPACE ------------
