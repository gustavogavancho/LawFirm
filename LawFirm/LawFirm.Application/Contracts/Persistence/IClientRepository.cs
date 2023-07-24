using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface IClientRepository : IAsyncRepository<Client>
{
}