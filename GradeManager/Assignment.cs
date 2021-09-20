using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class Assignment
    {
        public string AssignmentName { get; set; }
        public double AssignmentGrade { get; set; }
        public bool isComplete { get; set; }

        public Assignment(string AssignmentName)
        {
            this.AssignmentName = AssignmentName;
        }
    }
}
