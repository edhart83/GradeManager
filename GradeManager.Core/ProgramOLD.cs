using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeManager.Core
{
    class ProgramOLD
    {
        public static List<Classroom> courses = new List<Classroom>();

        public static Classroom classFromSystem;
        public static int classFromSystemIndex;

        // Create variable to store user's choice
        public static int menuChoice;

        static void Main(string[] args)
        {
            // Load dummy data to save time testing
            createDummyData();
            // Display Main/Courses Menu 
            Console.WriteLine("Welcome to Grade Manager!\n");
            Console.WriteLine("Please choose an option below:");
            Console.WriteLine("1. Show Courses\n" +
                                "2. Add Course\n" +
                                "3. Remove Course\n" +
                                "4. Classroom Details Menu\n" +
                                "0. Exit Application");
            Console.WriteLine("------------------");

            try // This makes sure user enters a number
            {
                menuChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid entry. Please choose an option between 1-4 or 0 to terminate the program.");
            }

            while (true) // Daniel Way helped me with this
            {
                switch (menuChoice)
                {
                    case 1: // --------- SHOW GRADES ---------
                        if (courses.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("No courses in the system...");
                            Console.WriteLine("Please select option #2 to add a course.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Number of Courses: " + courses.Count);
                            for (int i = 0; i < courses.Count; i++)
                            {
                                Console.WriteLine(courses[i].GetCourseName());
                            }
                        }
                        break;
                    case 2: // --------- ADD COURSE ---------
                        while (true) // This ensures the user enters a valid number less than 100
                        {
                            try
                            {
                                Console.WriteLine("Enter new course name: ");
                                string newCourse = Console.ReadLine();
                                Classroom courseToAdd = new Classroom(newCourse);
                                courses.Add(courseToAdd);
                                Console.Clear();
                                Console.WriteLine("The course " + newCourse + " was added!");
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid entry. Please try again.");
                            }
                            continue;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter course name to remove: ");
                        string usersEntry = Console.ReadLine();
                        Console.Clear();
                        for (int i = 0; i < courses.Count; i++)
                        {
                            if (courses[i].GetCourseName() == usersEntry)
                            {
                                courses.Remove(courses[i]);
                                Console.WriteLine("Success! The course " + usersEntry + " was removed!");
                            }
                        }
                        break;
                    case 4: //---------------- Display menu choices for (4) Classroom Details Menu ----------------
                        // Tell user they need to add a course if none exists
                        if (courses.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("No courses in the system...");
                            Console.WriteLine("Please select option #2 to add a course.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Current Courses: ");
                            for (int i = 0; i < courses.Count; i++)
                            {
                                Console.WriteLine(courses[i].GetCourseName());
                            }
                            // Ask user to select a course to edit from the list above
                            Console.WriteLine("\nPlease enter the name of the classroom you wish to see details of: ");
                            string classSelection = Console.ReadLine();
                            for (int i = 0; i < courses.Count; i++)
                            {
                                if (courses[i].GetCourseName() == classSelection)
                                {
                                    classFromSystem = courses[i];
                                    classFromSystemIndex = i;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("Currently Editing " + classFromSystem.GetCourseName() + " Classroom");
                            // I am passing in the course name so I can use it later
                            classFromSystem.runClassroomStudentDetails(classFromSystem, courses);
                            break; // Temporary Break from Courses Move Change
                        }  
                    case 0: // --------- TERMINATE PROGRAM ---------
                        return;
                    default:
                        break;
                } // ------------ END OF SWITCH ------------
                try
                {
                    // Display Main/Courses Menu
                    Console.WriteLine("\nCurrently Editing Courses");
                    Console.WriteLine("Please choose an option below:");
                    Console.WriteLine("1. Show Courses\n" +
                                        "2. Add Course\n" +
                                        "3. Remove Course\n" +
                                        "4. Classroom Details Menu\n" +
                                        "0. Exit Application");
                    Console.WriteLine("-------------------------");
                    menuChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid entry. Please choose an option between 1-4 or 0 to terminate the program.");
                }
            } // ------------ END OF WHILE ------------

            void createDummyData()
            {
                //Classroom Art = new Classroom("Art");
                //courses.Add(Art);
                //Student Ed = new Student("Ed", Art);
                //Assignment Lab1 = new Assignment("Lab1");
                //Lab1.AssignmentGrade = 100;
                //Ed.studentsAssignments.Add(Lab1);
                //Classroom.studentsList.Add(Ed);
            }

        } // ------------ END OF MAIN ------------
    } // ------------ END OF PROGRAM CLASS ------------
} // ------------ END OF GRADEMANAGER NAMESPACE ------------
