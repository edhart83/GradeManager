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
        public double gradeAverage { get; set; }
        public bool assignmentsCompleted { get; set; } = false;
        public int numberOfAssignments { get; set; } = 0;
        public Classroom studentsClass { get; set; }
        public List<Assignment> studentsAssignments;

        public Student(string name, Classroom studentsClass) 
        {
            this.name = name;
            this.studentsClass = studentsClass;
            this.studentsAssignments = new List<Assignment>();
        }


    }
}
