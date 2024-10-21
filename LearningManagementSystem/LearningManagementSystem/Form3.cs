using System;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public partial class Form3 : Form
    {
        private Teacher loggedInTeacher;

        public Form3(User user)
        {
            InitializeComponent();
            loggedInTeacher = (Teacher)user;
        }

        // Завантаження форми для викладача
        private void Form3_Load(object sender, EventArgs e)
        {
            var courses = loggedInTeacher.GetTeachingCourses();
            listBoxCourses.Items.Clear();
            foreach (var course in courses)
            {
                listBoxCourses.Items.Add(course.CourseName);
            }
        }

        // Вибір курсу і завантаження студентів
        private void listBoxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCourses.SelectedItem != null)
            {
                string selectedCourseName = listBoxCourses.SelectedItem.ToString();
                var selectedCourse = loggedInTeacher.GetTeachingCourses().Find(c => c.CourseName == selectedCourseName);

                if (selectedCourse != null)
                {
                    // Оновлюємо список студентів
                    listBoxStudents.Items.Clear();
                    foreach (var student in selectedCourse.EnrolledStudents)
                    {
                        listBoxStudents.Items.Add(student.Username);
                    }

                    // Додати конкретного студента 'student1', якщо потрібно
                    listBoxStudents.Items.Add("student1");

                    // Оновлюємо список завдань
                    listBoxAssignments.Items.Clear();
                    foreach (var assignment in selectedCourse.Assignments)
                    {
                        listBoxAssignments.Items.Add(assignment.AssignmentName);
                    }
                }
            }
        }


        // Призначення завдання студентам
        private void buttonAssignTask_Click(object sender, EventArgs e)
        {
            if (listBoxCourses.SelectedItem != null)
            {
                string selectedCourseName = listBoxCourses.SelectedItem.ToString();
                var selectedCourse = loggedInTeacher.GetTeachingCourses().Find(c => c.CourseName == selectedCourseName);

                if (selectedCourse != null)
                {
                    string assignmentName = textBoxAssignmentName.Text;
                    if (!string.IsNullOrEmpty(assignmentName))
                    {
                        var newAssignment = new Assignment { AssignmentName = assignmentName, TaskDescription = "Опис завдання" };
                        selectedCourse.AddAssignment(newAssignment);
                        MessageBox.Show($"Завдання '{assignmentName}' призначено для курсу {selectedCourseName}.");

                        // Оновлення списку завдань
                        listBoxAssignments.Items.Add(assignmentName);
                    }
                    else
                    {
                        MessageBox.Show("Назва завдання не може бути порожньою.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть курс.");
            }
        }

        // Оцінювання студента за конкретне завдання
        private void buttonGradeStudent_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(textBoxGrade.Text))
                {
                    MessageBox.Show("Введіть оцінку.");
                    return;
                }

                string selectedStudentUsername = listBoxStudents.SelectedItem.ToString();
                string gradeValue = textBoxGrade.Text;

                MessageBox.Show($"Оцінка '{gradeValue}' поставлена студенту '{selectedStudentUsername}'.");
            }
            else
            {
                MessageBox.Show("Виберіть студента.");
            }
        }
    }
}
