using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetAll() => _context.Clients.ToList();
        public Client? GetById(int id) => _context.Clients.Find(id);
        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        public void Update(Client client)
        {
            var trackedEntity = _context.Clients.Local.FirstOrDefault(c => c.Id == client.Id);
            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity).State = EntityState.Detached;
            }

            _context.Clients.Update(client);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
    }
}
