using System;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public partial class Form2 : Form
    {
        private User loggedInUser;

        public Form2(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (loggedInUser is Student)
            {
                MessageBox.Show($"Welcome, {loggedInUser.Username}! You are logged in as a Student.");
                // Додаткові налаштування для студента, якщо необхідно
            }
        }

        // Обробник події для кнопки "Перегляд оцінок"
        private void buttonViewGrades_Click(object sender, EventArgs e)
        {
            if (loggedInUser is Student student)
            {
                // Приклад відображення оцінок (замінити на фактичний метод отримання оцінок)
                var grades = student.GetGrades(); // Припустимо, що в класі Student є метод GetGrades()
                listBoxResults.Items.Clear();
                foreach (var grade in grades)
                {
                    listBoxResults.Items.Add(grade);
                }
            }
        }

        // Обробник події для кнопки "Перегляд завдань"
        private void buttonViewAssignments_Click(object sender, EventArgs e)
        {
            if (loggedInUser is Student student)
            {
                // Приклад відображення завдань (замінити на фактичний метод отримання завдань)
                var assignments = student.GetAssignments(); // Припустимо, що в класі Student є метод GetAssignments()
                listBoxResults.Items.Clear();
                foreach (var assignment in assignments)
                {
                    listBoxResults.Items.Add(assignment);
                }
            }
        }
    }
}