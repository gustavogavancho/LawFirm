using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(LawFirmContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Event>> FindEventsByStartDate(DateTime date)
    {
        var check = await _dbContext.Event.Where(x => x.EventStartDate.Date == date.Date).ToListAsync();

        var events = await _dbContext.Event.Where(x => x.EventStartDate.Date == date.Date && !x.IsNotified).ToListAsync();

        return events;
    }

    public async Task<List<Event>> FindEventBySearchTerm(string searchTerm)
    {
        var events = await _dbContext.Event.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()) || x.Description.ToLower().Contains(searchTerm.ToLower())).ToListAsync();

        return events;
    }
}