using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager.Core
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public string AssignmentName { get; set; }
        public double AssignmentGrade { get; set; }
        public bool isComplete { get; set; }
        public Student Student { get; set; }

        public Assignment(string AssignmentName)
        {
            this.AssignmentName = AssignmentName;
        }
    }
}
