using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public partial class Form4 : Form
    {
        private User loggedInUser; // Використовуємо існуючий клас User
        private List<Course> courses = new List<Course>(); // Зміна на список Course

        public Form4(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Додайте курси на старті
            LoadCourses();
            UpdateCourseList();
        }

        private void LoadCourses()
        {
            courses.Add(new Course { CourseName = "Курс 1" });
            courses.Add(new Course { CourseName = "Курс 2" });
        }

        private void UpdateCourseList()
        {
            listBoxCourses.Items.Clear();
            foreach (var course in courses)
            {
                listBoxCourses.Items.Add(course.CourseName);
            }
        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            string newCourseName = textBoxCourseName.Text;
            if (!string.IsNullOrWhiteSpace(newCourseName))
            {
                var newCourse = new Course { CourseName = newCourseName };
                courses.Add(newCourse); // Додаємо курс до списку
                UpdateCourseList(); // Оновлюємо список курсів
                MessageBox.Show("Курс додано: " + newCourseName);
            }
            else
            {
                MessageBox.Show("Назва курсу не може бути порожньою.");
            }
        }

        private void buttonDeleteCourse_Click(object sender, EventArgs e)
        {
            if (listBoxCourses.SelectedItem != null)
            {
                string selectedCourseName = listBoxCourses.SelectedItem.ToString();
                var courseToRemove = courses.Find(c => c.CourseName == selectedCourseName);
                if (courseToRemove != null)
                {
                    courses.Remove(courseToRemove); // Видалення з внутрішнього списку
                    UpdateCourseList(); // Оновлюємо список курсів
                    MessageBox.Show("Курс видалено: " + selectedCourseName);
                }
            }
            else
            {
                MessageBox.Show("Виберіть курс для видалення.");
            }
        }
    }
}
