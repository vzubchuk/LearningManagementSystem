using System;
using System.Windows.Forms;

namespace LearningManagementSystem
{
    public class Administrator : User
    {
        public Administrator(string username, string password) : base(username, password) { }

        public void ManageSystem()
        {
            MessageBox.Show($"{Username} is managing the system.");
        }
    }
}
