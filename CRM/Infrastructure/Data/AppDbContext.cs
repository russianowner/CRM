using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=crm.db");
        public void InitializeDatabase()
        {
            Database.EnsureCreated();
        }
    }
}
