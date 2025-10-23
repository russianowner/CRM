﻿public interface IClientRepository
{
    IEnumerable<Client> GetAll();
    Client? GetById(int id);
    void Add(Client client);
    void Update(Client client);
    void Delete(int id);
}
