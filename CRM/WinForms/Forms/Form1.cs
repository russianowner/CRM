namespace CRM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnClients_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Список клиентов";
            OpenChildForm(new FormClientList());
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Выйти из системы?", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show();
            }
        }
        private void OpenChildForm(Form childForm)
        {
            panelContent.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            childForm.Show();
        }
    }
}
