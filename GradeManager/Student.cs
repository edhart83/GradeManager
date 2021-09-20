using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class Student
    {
        public string name { get; set; }
        public bool assignmentsCompleted { get; set; } = false;
        public int numberOfAssignments { get; set; } = 0;
        public Classroom studentsClass { get; set; }
        public List<Assignment> studentsAssignments;
        public double highestGrade { get; set; }
        public double studentsAverageGrade = 0;
        public List<double> gradesList = new List<double>();

        public Student(string name, Classroom studentsClass) 
        {
            this.name = name;
            this.studentsClass = studentsClass;
            this.studentsAssignments = new List<Assignment>();
        }

        public Student(double highestAverage)
        {
        }

        public Student(string name)
        {
            this.name = name;
        }

        public void runEditStudentDetails(Student studentFromList, List<Student> studentsList)
        {
            Console.WriteLine("\nPlease choose an option below:");
            Console.WriteLine("1. Show Student Summary\n" +
                                "2. Assign Something to Student\n" +
                                "3. Unassign Something to Student\n" +
                                "4. Show Assignments\n" +
                                "5. Grade Assignments\n" +
                                "6. Show Students Best Grade\n" +
                                "7. how Students Worst Grade\n" +
                                "0. Exit this menu");
            Console.WriteLine("------------------");
            int menuChoice3 = int.Parse(Console.ReadLine());
            while (true) // Daniel Way helped me with this
            {
                switch (menuChoice3)
                {
                    case 1: // --------- SHOW STUDENT SUMMARY ---------
                        Console.Clear();
                        Console.WriteLine("Name: " + studentFromList.name);
                        //Console.WriteLine("Classes Enrolled In: " + studentsList[i].studentsClass);
                        Console.WriteLine("Number of Assignments: " + studentFromList.numberOfAssignments);
                        Console.WriteLine("Completed All Assignments: " + studentFromList.assignmentsCompleted);
                        Console.WriteLine("Average: " + GetStudentsGradeAverage());
                        Console.WriteLine("----------------------");
                        break;
                    case 2: // --------- ASSIGN SOMETHING TO STUDENT ---------
                        Console.Clear();
                        Console.WriteLine(studentFromList.name + "'s Assignments: ");
                        for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                        {
                            Console.WriteLine(studentFromList.studentsAssignments[i].AssignmentName);
                        }
                        Console.WriteLine("\nPlease Enter the name of the assignment to add:");
                        Assignment nameOfAssignmentToAdd = new Assignment(Console.ReadLine());
                        studentFromList.studentsAssignments.Add(nameOfAssignmentToAdd);
                        studentFromList.numberOfAssignments++;
                        Console.Clear();
                        Console.WriteLine("Success! " + nameOfAssignmentToAdd.AssignmentName + " was assigned to " + studentFromList.name);
                        break;
                    case 3: // --------- UNASSIGN SOMETHING TO STUDENT ---------
                        Console.Clear();
                        if (studentFromList.studentsAssignments.Count <= 0)
                        {
                            Console.WriteLine("No assignments assigned to " + studentFromList.name);
                            Console.WriteLine("Please select option #2 to add an assignment.");
                        }
                        else
                        {
                            Console.WriteLine(studentFromList.name + "'s Assignments: ");
                            for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                            {
                                Console.WriteLine(studentFromList.studentsAssignments[i].AssignmentName);
                            }
                            Console.WriteLine("\nPlease Enter the name of the assignment to remove:");
                            Assignment nameOfAssignmentToRemove = new Assignment(Console.ReadLine());
                            for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                            {
                                if (studentFromList.studentsAssignments[i].AssignmentName.Equals(nameOfAssignmentToRemove.AssignmentName))
                                {
                                    //studentFromList.studentsAssignments.RemoveAt(i);
                                    Console.WriteLine("Assignment is: " + i);
                                    studentFromList.studentsAssignments.RemoveAt(i);
                                }
                            }
                            studentFromList.numberOfAssignments--;
                            //Console.Clear();
                            Console.WriteLine("Success! The assignment " + nameOfAssignmentToRemove.AssignmentName + " was removed from " + studentFromList.name + "'s list.");
                        }
                        break;
                    case 4: //---------------- SHOW ASSIGNMENTS ----------------
                            // Tell user they need to add an Assignments if none exists
                        if (studentFromList.studentsAssignments.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(studentFromList.name + " has no assignments in the system...");
                            Console.WriteLine("Please select option #2 to add an assignment.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(studentFromList.name + "'s Assignments:");
                            for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                            {
                                Console.WriteLine(studentFromList.studentsAssignments[i].AssignmentName);
                            }
                            break;
                        }
                    case 5: // --------- GRADE ASSIGNMENTS ---------
                        // Tell user they need to add an Assignments if none exists
                        if (studentFromList.studentsAssignments.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(studentFromList.name + " has no assignments in the system...");
                            Console.WriteLine("Please select option #2 to add an assignment.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(studentFromList.name + "'s Assignments:");
                            for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                            {
                                Console.WriteLine(studentFromList.studentsAssignments[i].AssignmentName);
                            }
                            Console.WriteLine("\nPlease Enter the name of the assignment to add a grade:");
                            Assignment nameOfAssignmentToGrade = new Assignment(Console.ReadLine());
                            Console.WriteLine("Please Enter the grade for the assignment:");
                            double gradeOfAssignment = double.Parse(Console.ReadLine());
                            for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                            {
                                if (studentFromList.studentsAssignments[i].AssignmentName.Equals(nameOfAssignmentToGrade.AssignmentName))
                                {
                                    studentFromList.studentsAssignments[i].AssignmentGrade = gradeOfAssignment;
                                }
                            }
                            gradesList.Add(gradeOfAssignment);
                            GetStudentsGradeAverage(); // This should get the average of the students assignments
                            Console.Clear();
                            Console.WriteLine("Success! " + studentFromList.name + "'s assignment " + nameOfAssignmentToGrade.AssignmentName + " was updated with grade " + gradeOfAssignment);
                            break;
                        }
                    case 6: // --------- SHOW STUDENTS HIGHEST GRADE ---------
                        //try
                        //{
                            //double studentsHighestGrade = 0.0;
                            Console.Clear();
                            //for (int i = 0; i < studentFromList.studentsAssignments.Count; i++)
                            //{
                            //    for (int j = 0; j < studentFromList.studentsAssignments.Count-1; j++)
                            //    {
                            //        if (studentFromList.studentsAssignments[i].AssignmentGrade > studentFromList.studentsAssignments[j].AssignmentGrade)
                            //        {
                            //            studentsHighestGrade = studentFromList.studentsAssignments[i].AssignmentGrade;
                            //        }  else
                            //        {
                            //            studentsHighestGrade = studentFromList.studentsAssignments[j].AssignmentGrade;
                            //        }
                            //    }
                            //}
                            Console.WriteLine(studentFromList.name + " highest grade is: " + gradesList.Max());
                        //}
                        //catch (InvalidOperationException)
                        //{
                        //    Console.Clear();
                        //    Console.WriteLine("No grades in the system. Please select option #2 to add a grade.");
                        //}
                        //catch (Exception)
                        //{
                        //    Console.WriteLine("Invalid entry or not sure what happend");
                        //}
                        break;
                    case 7: // --------- SHOW LOWEST GRADE ---------
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(studentFromList.name + " lowest grade is: " + gradesList.Min());
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
                    case 0: // --------- TERMINATE PROGRAM ---------
                        Console.Clear();
                        return;
                    default:
                        break;
                } // ------------ END OF SWITCH ------------

                try
                {
                    // Display Main/Courses Menu
                    Console.WriteLine("\nCurrently Editing Student: " + studentFromList.name);
                    Console.WriteLine("Please choose an option below:");
                    Console.WriteLine("1. Show Student Summary\n" +
                                        "2. Assign Something to Student\n" +
                                        "3. Unassign Something to Student\n" +
                                        "4. Show Assignments\n" +
                                        "5. Grade Assignments\n" +
                                        "6. Show Students Best Grade\n" +
                                        "7. how Students Worst Grade\n" +
                                        "0. Exit this menu");
                    Console.WriteLine("------------------");
                    menuChoice3 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid entry. Please choose an option between 1-8");
                }

            } // ------------ END OF WHILE ------------

        } // ------------ END OF runEditStudentDetails Method ------------

        public double GetStudentsGradeAverage()
        {
            studentsAverageGrade = gradesList.Average();
            return studentsAverageGrade; 
        }
    }
}
