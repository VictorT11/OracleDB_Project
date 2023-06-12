using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();


            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Width, 35);
        }

        private void LoginBut_Click(object sender, EventArgs e)
        {
            string pass = "admin";
            if (this.passField.Text == pass && this.userField.Text == pass)
            {
                this.Hide();
                AdminForm a = new AdminForm();
                a.Show();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
        }
    }
}
