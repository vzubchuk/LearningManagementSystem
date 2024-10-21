using System;
using System.Collections.Generic;

namespace LearningManagementSystem
{
    public class Course
    {
        public string CourseName { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public Teacher CourseTeacher { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public void AddLecture(Lecture lecture)
        {
            Lectures.Add(lecture);
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void EnrollStudent(Student student)
        {
            EnrolledStudents.Add(student);
        }
    }
}
