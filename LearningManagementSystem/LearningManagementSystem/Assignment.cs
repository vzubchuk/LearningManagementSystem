using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public class Assignment
    {
        public string AssignmentName { get; set; }
        public string TaskDescription { get; set; }
        public Dictionary<Student, Grade> StudentGrades { get; set; } = new Dictionary<Student, Grade>();

        // Метод для викладача, щоб оцінити студента
        public void SetGrade(Student student, Grade grade)
        {
            if (StudentGrades.ContainsKey(student))
            {
                StudentGrades[student] = grade;
            }
            else
            {
                StudentGrades.Add(student, grade);
            }
        }
    }

}
