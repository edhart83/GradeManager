using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class Classroom
    {
        private string CourseName { get; set; }

        public static List<Student> studentsList = new List<Student>();
        //public static List<Classroom> CoursesList = new List<Classroom>();
        int numberOfStudentsInClass = 0;

        public Classroom() { }
        public Classroom(string courseName)
        {
            CourseName = courseName;
        }

        public string GetCourseName()
        {
            return this.CourseName;
        }

        public void runClassroomStudentDetails(Classroom classFromSystem, List<Classroom> courses)
        {
            Console.WriteLine("\nPlease choose an option below:");
            Console.WriteLine("1. Show Students\n" +
                                "2. Add Students\n" +
                                "3. Remove Students\n" +
                                "4. Student Details Menu\n" +
                                "5. Show Class Average\n" +
                                "6. Show Top Student\n" +
                                "7. Show Bottom Student\n" +
                                "8. Compare Two Students\n" +
                                "0. Exit this menu");
            Console.WriteLine("------------------");
            int menuChoice2 = int.Parse(Console.ReadLine());
            while (true) // Daniel Way helped me with this
            {
                switch (menuChoice2)
                {
                    case 1: // --------- SHOW STUDENTS ---------
                        Console.Clear();
                        Console.WriteLine("Number of Students in " + classFromSystem.CourseName + " class: " + numberOfStudentsInClass);
                        if (numberOfStudentsInClass == 0)
                        {
                            Console.WriteLine("Please select option #2 to add a student to " + classFromSystem.CourseName + " class.");
                        }
                        if (studentsList.Count > 0)
                        {
                            for (int i = 0; i < studentsList.Count; i++)
                            {
                                if (studentsList[i].studentsClass == classFromSystem)
                                {
                                    Console.WriteLine("Name: " + studentsList[i].name);
                                    //Console.WriteLine("Class Name: " + studentsList[i].studentsClass);
                                    Console.WriteLine("Average: " + studentsList[i].gradeAverage);
                                    Console.WriteLine("Completed All Assignments: " + studentsList[i].assignmentsCompleted);
                                    Console.WriteLine("Number of Assignments: " + studentsList[i].numberOfAssignments);
                                    Console.WriteLine("----------------------"); 
                                } else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("No students in " + classFromSystem.CourseName + " class...");
                            Console.WriteLine("Please select option #2 to add a student to " + classFromSystem.CourseName + " class.");
                        }
                        break;
                    case 2: // --------- ADD STUDENT ---------
                        while (true)
                        {
                            try
                            {
                            Console.WriteLine("Please enter the name of the student you wish to add to " + classFromSystem.CourseName + " class.");
                            Student newStudent = new Student(Console.ReadLine(), classFromSystem);
                            newStudent.studentsClass = classFromSystem;
                            studentsList.Add(newStudent);
                                // ------------- I was doing a for loop here, not sure why. It was messing up my code. I just needed the if condition below.
                                //foreach (Student item in studentsList)
                                //{
                                //Console.WriteLine("classFromSystem: " + classFromSystem.CourseName);
                                //Console.WriteLine("item: " + newStudent.studentsClass.GetCourseName());
                                //    if (item.studentsClass.GetCourseName() == classFromSystem.CourseName)
                                //    {
                                //        numberOfStudentsInClass++;
                                //    }
                                //    break;
                                //}
                            if (newStudent.studentsClass.GetCourseName() == classFromSystem.CourseName)
                            {
                                numberOfStudentsInClass++;
                            }
                            //Console.Clear();
                            Console.WriteLine("Size of studentsList: " + studentsList.Count);
                            Console.WriteLine("# of numberOfStudentsInClass: " + numberOfStudentsInClass);
                            //Console.Clear();
                            Console.WriteLine("Success! New student " + newStudent.name + " was added to " + classFromSystem.CourseName + " class.");
                            break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid entry. Please try again.");
                            }
                            continue;
                        }
                        break;
                        //case 3: // --------- SHOW CLASS AVERAGE ---------
                        //    try
                        //    {
                        //        Console.Clear();
                        //        Console.WriteLine("The average grade is: " + studentsList.Average());
                        //    }
                        //    catch (InvalidOperationException)
                        //    {
                        //        Console.Clear();
                        //        Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        //    }
                        //    catch (Exception)
                        //    {
                        //        Console.WriteLine("Invalid entry or not sure what happend");
                        //    }
                        //    break;
                        //case 4: // --------- SHOW HIGHEST GRADE ---------
                        //    try
                        //    {
                        //        Console.Clear();
                        //        Console.WriteLine("The highest grade is: " + studentsList.Max());
                        //    }
                        //    catch (InvalidOperationException)
                        //    {
                        //        Console.Clear();
                        //        Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        //    }
                        //    catch (Exception)
                        //    {
                        //        Console.WriteLine("Invalid entry or not sure what happend");
                        //    }
                        //    break;
                        //case 5: // --------- SHOW LOWEST GRADE ---------
                        //    try
                        //    {
                        //        Console.Clear();
                        //        Console.WriteLine("The lowest grade is: " + studentsList.Min());
                        //    }
                        //    catch (InvalidOperationException)
                        //    {
                        //        Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        //    }
                        //    catch (Exception)
                        //    {
                        //        Console.WriteLine("Invalid entry or not sure what happend");
                        //    }
                        //    break;
                        //case 6: // --------- REMOVE GRADE ---------
                        //    Console.Clear();
                        //    while (true)
                        //    {  // This ensures the user selects a valid index
                        //        if (studentsList.Count > 0)
                        //        {
                        //            for (int i = 0; i < studentsList.Count; i++)
                        //            {
                        //                Console.WriteLine("Student " + i + ": " + studentsList[i]);
                        //            }
                        //            try
                        //            {
                        //                Console.WriteLine("Select a grade to remove by typing the students id number");
                        //                int studentID = Convert.ToInt32(Console.ReadLine());
                        //                studentsList.RemoveAt(studentID);
                        //                Console.Clear();
                        //                Console.WriteLine("Student " + studentID + " has been removed from the list.");
                        //                break;
                        //            }
                        //            catch (FormatException)
                        //            {
                        //                Console.WriteLine("Invalid entry. Please select a number between 0 and " + (studentsList.Count() - 1));
                        //            }
                        //            catch (ArgumentOutOfRangeException)
                        //            {
                        //                Console.WriteLine("Invalid entry. Please select a number between 0 and " + (studentsList.Count() - 1));
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Console.Clear();
                        //            Console.WriteLine("No grades found. Please add a grade.");
                        //        }
                        //        continue;
                        //    }
                        //    break;
                        //case 7: // --------- EDIT GRADE ---------
                        //    Console.Clear();
                        //    if (studentsList.Count > 0)
                        //    {
                        //        for (int i = 0; i < studentsList.Count; i++)
                        //        {
                        //            Console.WriteLine("Student " + i + ": " + studentsList[i]);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("No grades found. Please add a grade by selecting option #2");
                        //        break;
                        //    }
                        //    while (true)
                        //    {
                        //        try
                        //        {
                        //            Console.WriteLine("Edit a grade by typing the student id and then the grade value, separated by a comma. (ie \"1,55.9\")");
                        //            string enteredValue = Console.ReadLine();
                        //            string[] splitValue = enteredValue.Split(',');
                        //            int studentID = Convert.ToInt32(splitValue[0]);
                        //            double newTempGrade = Convert.ToDouble(splitValue[1]);
                        //            studentsList[studentID] = newTempGrade;
                        //            Console.WriteLine("Grade updated!");
                        //            break;
                        //        }
                        //        catch (FormatException)
                        //        {
                        //            Console.WriteLine("Invalid entry. Enter student id and then the grade value, separated by a comma. (ie \"1,55.9\")");
                        //            continue;
                        //        }
                        //        catch (IndexOutOfRangeException)
                        //        {
                        //            Console.WriteLine("Invalid entry. Enter student id and then the grade value, separated by a comma. (ie \"1,55.9\")");
                        //            continue;
                        //        }
                        //    }
                        //break;
                    case 0: // --------- TERMINATE PROGRAM ---------
                        Console.Clear();
                        return;
                    default:
                        break;
                } // ------------ END OF SWITCH ------------

                try
                {
                    // Display Main/Courses Menu
                    Console.WriteLine("\nCurrently Editing Classroom");
                    Console.WriteLine("Please choose an option below:");
                    Console.WriteLine("1. Show Students\n" +
                                        "2. Add Students\n" +
                                        "3. Remove Students\n" +
                                        "4. Student Details Menu\n" +
                                        "5. Show Class Average\n" +
                                        "6. Show Top Student\n" +
                                        "7. Show Bottom Student\n" +
                                        "8. Compare Two Students\n" +
                                        "0. Exit this menu");
                    Console.WriteLine("------------------");
                    menuChoice2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid entry. Please choose an option between 1-8");
                }

            } // ------------ END OF WHILE ------------
            
        }
    }
}

