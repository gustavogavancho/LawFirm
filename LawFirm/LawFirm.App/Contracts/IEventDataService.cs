using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IEventDataService
{
    Task<EventVm> CreateEvent(EventVm request);
    Task<EventVmPagingResponse> GetPagedEvents(int? pageNumber, int? pageSize);
    Task<ICollection<EventVm>> GetEvents();
    Task<ICollection<EventVm>> FindEventsBySearchTerm(string searchTerm);
    Task<ICollection<EventVm>> FindEventsByStartDate(DateTime date);
    Task<EventVm> GetEvent(Guid id);
    Task UpdateEvent(Guid id, EventVm request);
    Task DeleteEvent(Guid id);
}