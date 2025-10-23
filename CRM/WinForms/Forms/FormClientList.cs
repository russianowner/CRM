using CRM.Application.DTOs;
using CRM.Infrastructure.Data;
using CRM.Infrastructure.Repositories;

namespace CRM
{
    public partial class FormClientList : Form
    {
        private readonly ClientService _clientService;
        private List<ClientDto> _allClients = new();

        public FormClientList()
        {
            InitializeComponent();
            var context = new AppDbContext();
            context.InitializeDatabase();
            var repo = new ClientRepository(context);
            _clientService = new ClientService(repo);
            LoadClients();
        }
        private void LoadClients()
        {
            _allClients = _clientService.GetAllClients();
            dgvClients.DataSource = _allClients;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            var filtered = _allClients
                .Where(c => c.FullName.ToLower().Contains(search) ||
                            c.Email.ToLower().Contains(search) ||
                            c.Phone.Contains(search))
                .ToList();
            dgvClients.DataSource = filtered;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = Prompt("Введите имя клиента:");
            var email = Prompt("Введите почту:");
            var phone = Prompt("Введите телефон:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                var dto = new ClientDto(0, name, email, phone);
                _clientService.AddClient(dto);
                LoadClients();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
                return;
            var selected = (ClientDto)dgvClients.CurrentRow.DataBoundItem;
            var name = Prompt("Новое имя:", selected.FullName);
            var email = Prompt("Новая почта:", selected.Email);
            var phone = Prompt("Новый телефон:", selected.Phone);
            selected.FullName = name;
            selected.Email = email;
            selected.Phone = phone;
            _clientService.UpdateClient(selected);
            LoadClients();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
                return;
            var selected = (ClientDto)dgvClients.CurrentRow.DataBoundItem;
            var confirm = MessageBox.Show($"Удалить клиента {selected.FullName}?",
                "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _clientService.DeleteClient(selected.Id);
                LoadClients();
            }
        }
        private string Prompt(string text, string defaultValue = "")
        {
            return Microsoft.VisualBasic.Interaction.InputBox(text, "CRM", defaultValue);
        }
    }
}
