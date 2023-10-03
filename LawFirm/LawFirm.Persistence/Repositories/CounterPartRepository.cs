using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;

namespace LawFirm.Persistence.Repositories;

public class CounterPartRepository : BaseRepository<CounterPart>, ICounterPartRepository
{
    public CounterPartRepository(LawFirmContext dbContext) : base(dbContext)
    {
    }
}