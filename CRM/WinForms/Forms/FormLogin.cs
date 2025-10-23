using System;
using System.Windows.Forms;

namespace CRM
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();
            if (IsValidUser(username, password))
            {
                this.Hide();
                var mainForm = new Form1();
                mainForm.Show();
            }
            else
            {
                lblError.Text = "Неверный логин или пароль";
            }
        }
        private bool IsValidUser(string username, string password)
        {
            return username == "admin" && password == "1234";
        }
    }
}
