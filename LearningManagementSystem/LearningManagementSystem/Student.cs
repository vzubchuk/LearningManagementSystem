using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public class Student : User
    {
        private List<string> grades;
        private List<string> assignments;
        private List<Course> enrolledCourses = new List<Course>();

        public Student(string username, string password) : base(username, password)
        {
            grades = new List<string> { "Math: A", "Science: B+", "History: A-" };
            assignments = new List<string> { "Math Homework", "Science Project", "History Essay" };
        }

        public void EnrollInCourse(Course course)
        {
            enrolledCourses.Add(course);
        }

        public List<Course> GetEnrolledCourses()
        {
            return enrolledCourses;
        }

        public void AccessLectures()
        {
            MessageBox.Show($"{Username} is viewing lectures.");
        }

        public List<string> GetGrades()
        {
            return grades;
        }

        public List<string> GetAssignments()
        {
            return assignments;
        }
    }
}
