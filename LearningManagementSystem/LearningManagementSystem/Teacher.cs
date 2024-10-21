using LearningManagementSystem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.Generic;
using System.Windows.Forms;

public class Teacher : User
{
    private List<Course> teachingCourses = new List<Course>();

    public Teacher(string username, string password) : base(username, password) { }

    // Метод для додавання курсу викладачу
    public void AssignToCourse(Course course)
    {
        teachingCourses.Add(course);
    }

    // Отримати список курсів, які веде викладач
    public List<Course> GetTeachingCourses()
    {
        return teachingCourses;
    }

    // Метод для завантаження лекцій на конкретний курс
    public void UploadLecture(Course course, Lecture lecture)
    {
        if (teachingCourses.Contains(course))
        {
            course.AddLecture(lecture);
            MessageBox.Show($"{Username} завантажив лекцію '{lecture.LectureName}' на курс '{course.CourseName}'.");
        }
        else
        {
            MessageBox.Show("Цей курс не належить викладачу.");
        }
    }

    // Метод для призначення оцінок студентам за завдання
    public void GradeStudent(Course course, Student student, Assignment assignment, Grade grade)
    {
        if (teachingCourses.Contains(course))
        {
            assignment.SetGrade(student, grade);
            MessageBox.Show($"Студента {student.Username} оцінено на {grade.GradeValue} за завдання '{assignment.AssignmentName}' у курсі '{course.CourseName}'.");
        }
        else
        {
            MessageBox.Show("Цей курс не належить викладачу.");
        }
    }
}
