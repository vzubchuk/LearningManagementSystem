using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public partial class Form1 : Form
    {
        private List<User> users;

        public Form1()
        {
            InitializeComponent();
            InitializeUsers();
        }

        // Ініціалізація користувачів та курсів
        private void InitializeUsers()
        {
            // Створення викладача
            var teacher = new Teacher("teacher1", "pass2");

            // Створення курсів і призначення їх викладачу
            var course1 = new Course { CourseName = "Програмування", CourseTeacher = teacher };
            var course2 = new Course { CourseName = "Математика", CourseTeacher = teacher };

            teacher.AssignToCourse(course1);  // Додаємо курс викладачу
            teacher.AssignToCourse(course2);  // Додаємо курс викладачу

            // Створення студента
            var student = new Student("student1", "pass1");

            // Зарахування студента на курси
            student.EnrollInCourse(course1);
            student.EnrollInCourse(course2);

            // Створення адміністратора
            var admin = new Administrator("admin1", "pass3");

            // Додавання користувачів до списку
            users = new List<User> { student, teacher, admin };
        }

        // Обробка натискання на кнопку логіну
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                user.Login();
                OpenUserWindow(user);
            }
            else
            {
                MessageBox.Show("Неправильні облікові дані.");
            }
        }

        // Відкриття відповідної форми для кожного типу користувача
        private void OpenUserWindow(User user)
        {
            Form nextForm;

            if (user is Student)
            {
                nextForm = new Form2(user);  // Відкриваємо форму для студента
            }
            else if (user is Teacher)
            {
                nextForm = new Form3(user);  // Відкриваємо форму для викладача
            }
            else if (user is Administrator)
            {
                nextForm = new Form4(user);  // Відкриваємо форму для адміністратора
            }
            else
            {
                return;
            }

            nextForm.Show();
            this.Hide();
        }
    }
}
