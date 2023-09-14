using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface IClientRepository : IAsyncRepository<Client>
{
    Task<List<Client>> FindCliendBySearchTerm(string searchTerm);
}