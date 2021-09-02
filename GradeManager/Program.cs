using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeManager
{
    class Program
    {
        // Create list to hold grades
        public static List<double> gradesList = new List<double>() {};

        // Create variable to store user's choice
        public static int menuChoice;

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

            try // This makes sure user enters a number
            {
                menuChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid entry. Please choose an option between 1-8");
            }

            //// Create variable to store user's choice
            //int menuChoice = Convert.ToInt32(Console.ReadLine());

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
                            Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        }
                        break;
                    case 2: // --------- ADD GRADE ---------
                        while (true) // This ensures the user enters a valid number less than 100
                        {
                            try
                            {
                                Console.WriteLine("Add grade as a decimal value or whole number. (ie 34.5) and less than or qual to 100");
                                double newGrade = Convert.ToDouble(Console.ReadLine());
                                if (newGrade > 100)
                                {
                                    Console.WriteLine("Please enter a number less than or equal to 100");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Grade added! The grade you entered was: " + newGrade);
                                    gradesList.Add(newGrade);
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid entry. Please try again.");
                            }
                            continue;
                        }
                        break;
                    case 3: // --------- SHOW CLASS AVERAGE ---------
                        try
                        {
                            Console.WriteLine("The average grade is: " + gradesList.Average());
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid entry or not sure what happend");
                        }
                        break;
                    case 4: // --------- SHOW HIGHEST GRADE ---------
                        try
                        {
                            Console.WriteLine("The highest grade is: " + gradesList.Max());
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid entry or not sure what happend");
                        }
                        break;
                    case 5: // --------- SHOW LOWEST GRADE ---------
                        try
                        {
                            Console.WriteLine("The lowest grade is: " + gradesList.Min());
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid entry or not sure what happend");
                        }
                        break;
                    case 6: // --------- REMOVE GRADE ---------
                        while (true) {  // This ensures the user selects a valid index
                            if (gradesList.Count > 0)
                            {
                                for (int i = 0; i < gradesList.Count; i++)
                                {
                                    Console.WriteLine("Student " + i + ": " + gradesList[i]);
                                }
                                try {
                                    Console.WriteLine("Select a grade to remove by typing the students id number");
                                    int studentID = Convert.ToInt32(Console.ReadLine());
                                    gradesList.RemoveAt(studentID);
                                    Console.WriteLine("Student " + studentID + " has been removed from the list.");
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid entry. Please select a number between 0 and " + (gradesList.Count() - 1));
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid entry. Please select a number between 0 and " + (gradesList.Count() - 1));
                                }
                            }
                            else
                            {
                                Console.WriteLine("No grades found. Please add a grade.");
                            }
                            continue;
                        }
                        break;
                    case 7: // --------- EDIT GRADE ---------
                        if (gradesList.Count > 0)
                        {
                            for (int i = 0; i < gradesList.Count; i++)
                            {
                                Console.WriteLine("Student " + i + ": " + gradesList[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No grades found. Please add a grade by selecting option #2");
                            break;
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Edit a grade by typing the student id and then the grade value, separated by a comma. (ie \"1,55.9\")");
                                string enteredValue = Console.ReadLine();
                                string[] splitValue = enteredValue.Split(',');
                                int studentID = Convert.ToInt32(splitValue[0]);
                                double newTempGrade = Convert.ToDouble(splitValue[1]);
                                gradesList[studentID] = newTempGrade;
                                Console.WriteLine("Grade updated!");
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid entry. Enter student id and then the grade value, separated by a comma. (ie \"1,55.9\")");
                                continue;
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Invalid entry. Enter student id and then the grade value, separated by a comma. (ie \"1,55.9\")");
                                continue;
                            }
                        }
                        break;
                    case 8: // --------- TERMINATE PROGRAM ---------
                        return;
                    default:
                        break;
                } // ------------ END OF SWITCH ------------
                
                try
                {
                    Console.WriteLine("Please choose a valid option between 1-8");
                    menuChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid entry. Please choose an option between 1-8");
                }

            } // ------------ END OF WHILE ------------

        } // ------------ END OF MAIN ------------

    } // ------------ END OF PROGRAM CLASS ------------
} // ------------ END OF GRADEMANAGER NAMESPACE ------------
