using CRM.Application.DTOs;
public class ClientService
{
    private readonly IClientRepository _repo;

    public ClientService(IClientRepository repo)
    {
        _repo = repo;
    }
    public List<ClientDto> GetAllClients() =>
        _repo.GetAll().Select(c => new ClientDto(c.Id, c.FullName, c.Email, c.Phone)).ToList();
    public void AddClient(ClientDto dto) =>
        _repo.Add(new Client { FullName = dto.FullName, Email = dto.Email, Phone = dto.Phone });
    public void UpdateClient(ClientDto dto) =>
        _repo.Update(new Client { Id = dto.Id, FullName = dto.FullName, Email = dto.Email, Phone = dto.Phone });
    public void DeleteClient(int id) => _repo.Delete(id);
}
