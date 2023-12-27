using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class EventDataService : BaseDataService, IEventDataService
{
    private readonly IMapper _mapper;

    public EventDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<EventVm> CreateEvent(EventVm request)
    {
        var responseMapped = _mapper.Map<CreateEventCommand>(request);

        var response = await _client.CreateEventAsync(responseMapped);

        return response;
    }

    public async Task DeleteEvent(Guid id)
    {
        await _client.DeleteEventAsync(id);
    }

    public async Task<EventVm> GetEvent(Guid id)
    {
        var selectedEvent = await _client.GetEventAsync(id);

        return selectedEvent;
    }

    public async Task<ICollection<EventVm>> GetEvents()
    {
        var events = await _client.GetEventsAsync();

        return events;
    }

    public async Task<EventVmPagingResponse> GetPagedEvents(int? pageNumber, int? pageSize)
    {
        var pagedEvents = await _client.GetPagedEventsAsync(pageNumber, pageSize);

        return pagedEvents;
    }

    public async Task UpdateEvent(Guid id, ClientVm request)
    {
        var requestMapped = _mapper.Map<UpdateEventCommand>(request);

        requestMapped.Id = id;

        await _client.UpdateEventAsync(requestMapped);
    }
}