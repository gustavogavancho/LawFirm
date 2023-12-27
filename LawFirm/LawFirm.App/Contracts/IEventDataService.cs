using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IEventDataService
{
    Task<EventVm> CreateEvent(EventVm request);
    Task<EventVmPagingResponse> GetPagedEvents(int? pageNumber, int? pageSize);
    Task<ICollection<EventVm>> GetEvents();
    Task<EventVm> GetEvent(Guid id);
    Task UpdateEvent(Guid id, ClientVm request);
    Task DeleteEvent(Guid id);
}