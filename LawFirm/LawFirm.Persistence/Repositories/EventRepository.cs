using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;

namespace LawFirm.Persistence.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(LawFirmContext dbContext) : base(dbContext)
    {
    }
}