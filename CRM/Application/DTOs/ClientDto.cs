namespace CRM.Application.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public ClientDto() { }
        public ClientDto(int id, string fullName, string email, string phone)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"{FullName} ({Email}, {Phone})";
        }
    }
}
