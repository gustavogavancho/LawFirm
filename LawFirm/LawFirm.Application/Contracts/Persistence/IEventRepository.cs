using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface IEventRepository : IAsyncRepository<Event>
{
    Task<List<Event>> FindEventBySearchTerm(string searchTerm);
}