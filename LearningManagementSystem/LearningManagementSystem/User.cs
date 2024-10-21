using System;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public virtual void Login()
        {
            MessageBox.Show($"{Username} logged in.");
        }
    }
}
