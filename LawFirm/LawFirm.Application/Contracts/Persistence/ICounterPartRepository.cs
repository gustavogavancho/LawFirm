using LawFirm.Domain.Entities;

namespace LawFirm.Application.Contracts.Persistence;

public interface ICounterPartRepository : IAsyncRepository<CounterPart>
{
}