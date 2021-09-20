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
        public static int classFromSystemIndex;
        public static string topStudent;
        public static Student bottomStudent;
        public static double lowestGradeAverage;
        public double average = 0;
        public static List<double> courseAverage = new List<double>();

        public static Student studentFromList;

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
                                    Console.WriteLine("Average: " + studentsList[i].GetStudentsGradeAverage());
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
                                Console.Clear();
                                Console.WriteLine("Number of all students in the system: " + studentsList.Count);
                            Console.WriteLine("Number of students in this particular class: " + numberOfStudentsInClass);
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
                    case 3: // --------- REMOVE STUDENTS ---------
                        Console.Clear();
                        Console.WriteLine("Students in " + classFromSystem.CourseName + " class:");
                        while (true)
                        {  // This ensures the user selects a valid index
                            if (studentsList.Count > 0)
                            {
                                for (int i = 0; i < studentsList.Count; i++)
                                {
                                    if (studentsList[i].studentsClass.GetCourseName() == classFromSystem.GetCourseName())
                                    {
                                        Console.WriteLine(studentsList[i].name);
                                    }
                                }
                                Console.WriteLine("Please Enter the name of the student you wish to remove:");
                                string studentToRemove = Console.ReadLine();
                                for (int i = 0; i < studentsList.Count; i++)
                                {
                                    if (studentsList[i].name == studentToRemove && studentsList[i].studentsClass.GetCourseName() == classFromSystem.GetCourseName())
                                    {
                                        studentsList.Remove(studentsList[i]);
                                        numberOfStudentsInClass--;
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("Success! Student " + studentToRemove + " has been removed from " + classFromSystem.CourseName + " class:");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No students found. Please add a student.");
                            }
                            continue;
                        }
                        break;
                    case 4: //---------------- Display menu choices for (4) Student Details Menu ----------------
                        // Tell user they need to add a course if none exists
                        if (studentsList.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("No students in the system...");
                            Console.WriteLine("Please select option #2 to add a student.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Current Students: ");
                            for (int i = 0; i < studentsList.Count; i++)
                            {
                                Console.WriteLine(studentsList[i].name);
                            }
                            // Ask user to select a student to edit from the list above
                            Console.WriteLine("\nPlease enter the name of the student you wish to see details of: ");
                            string studentSelection = Console.ReadLine();
                            for (int i = 0; i < studentsList.Count; i++)
                            {
                                if (studentsList[i].name == studentSelection)
                                {
                                    studentFromList = studentsList[i];
                                    classFromSystemIndex = i;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("Currently Editing Student: " + studentFromList.name);
                            //// I am passing in the course name so I can use it later
                            studentFromList.runEditStudentDetails(studentFromList, studentsList);
                            break; // Temporary Break from Courses Move Change
                        }
                    case 5: // --------- SHOW CLASS AVERAGE GRADE ---------
                        try
                        {
                            Console.Clear();
                            average = GetClassAverage();
                            Console.WriteLine("The classroom average grade is: " + average);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.Clear();
                            Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid entry or not sure what happend");
                        }
                        break;
                    case 6: // --------- SHOW TOP STUDENT ---------
                        try
                        {
                            double studentsAverage = 0;
                            //Student tempTopStudent = new Student(Student.gradesList.Max());
                            for (int i = 0; i < studentsList.Count; i++)
                            {
                                studentsAverage = studentsList[i].GetStudentsGradeAverage();
                                if (studentsAverage > average)
                                {
                                    topStudent = studentsList[i].name;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("The Top Student is " + topStudent + " with an average grade of: "+ studentFromList.GetStudentsGradeAverage());
                        }
                        catch (InvalidOperationException)
                        {
                            Console.Clear();
                            Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid entry or not sure what happend");
                        }
                        break;
                    case 7: // --------- SHOW BOTTOM STUDENT --------- // Probably didn't do this right. Rushing to finish now
                        double studentsAverage2 = 0;
                        //Student tempTopStudent = new Student(Student.gradesList.Max());
                        for (int i = 0; i < studentsList.Count; i++)
                        {
                            for (int j = 0; j < studentsList.Count - 1; j++)
                            {
                                studentsAverage2 = studentsList[i].GetStudentsGradeAverage();
                                if (studentsList[i].GetStudentsGradeAverage() < average && studentsList[i].GetStudentsGradeAverage() < studentsList[j].GetStudentsGradeAverage())
                                {
                                    bottomStudent = new Student(studentsList[i].name);
                                    lowestGradeAverage = courseAverage.Min();
                                } 
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("The Bottom Student is " + bottomStudent.name + " with an average grade of: " + lowestGradeAverage);
                        break;
                    case 8: // --------- COMPARE TWO STUDENTS ---------
                        Console.Clear();
                        Console.WriteLine("Current Students: ");
                        for (int i = 0; i < studentsList.Count; i++)
                        {
                            Console.WriteLine(studentsList[i].name);
                        }
                        Console.WriteLine("\nPlease Enter the name of the first student:");
                        Student firstStudent = new Student(Console.ReadLine());
                        Console.WriteLine("\nPlease Enter the name of the second student:");
                        Student secondStudent = new Student(Console.ReadLine());
                        for (int i = 0; i < studentsList.Count; i++)
                        {
                            if (studentsList[i].name == firstStudent.name)
                            {
                                firstStudent = studentsList[i];
                            } else if (studentsList[i].name == secondStudent.name)
                            {
                                secondStudent = studentsList[i];
                            } else
                            {
                                Console.WriteLine("Error: Student is not in the system!");
                            }
                        }
                        if (firstStudent.GetStudentsGradeAverage() > secondStudent.GetStudentsGradeAverage())
                        {
                            Console.WriteLine(firstStudent.name + " is a better student.");
                        } else
                        {
                            Console.WriteLine(secondStudent.name + " is a better student.");
                        }
                        break;
                    case 0: // --------- TERMINATE PROGRAM ---------
                        Console.Clear();
                        return;
                    default:
                        break;
                } // ------------ END OF SWITCH ------------

                try
                {
                    // Display Main/Courses Menu
                    Console.WriteLine("\nCurrently Editing " + classFromSystem.CourseName + " Classroom");
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

        } // ------------ END OF runClassroomStudentDetails ------------

        public static double GetClassAverage()
        {
            double classAverage = 0;
            for (int i = 0; i < studentsList.Count; i++)
            {
                courseAverage.Add(studentsList[i].GetStudentsGradeAverage());
            }
            classAverage = courseAverage.Average();
            return classAverage;
        }
    }
}

