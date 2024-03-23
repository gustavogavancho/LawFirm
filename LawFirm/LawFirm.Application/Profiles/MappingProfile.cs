using AutoMapper;
using LawFirm.Application.Features.Cases.Commands.CreateCase;
using LawFirm.Application.Features.Cases.Commands.UpdateCase;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Features.Clients.Commands.UpdateClient;
using LawFirm.Application.Features.Clients.Models;
using LawFirm.Application.Features.Events.Commands.CreateEvent;
using LawFirm.Application.Features.Events.Commands.UpdateEvent;
using LawFirm.Application.Features.Events.Models;
using LawFirm.Domain.Entities;

namespace LawFirm.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, CreateClientCommand>().ReverseMap();
        CreateMap<Client, ClientVm>().ReverseMap();
        CreateMap<Client, UpdateClientCommand>().ReverseMap();

        CreateMap<Case, CreateCaseCommand>().ReverseMap();
        CreateMap<Case, UpdateCaseCommand>().ReverseMap();
        CreateMap<Case, CaseVm>().ReverseMap();

        CreateMap<CounterPart, CounterPartVm>().ReverseMap();

        CreateMap<Charge, ChargeVm>().ReverseMap();

        CreateMap<Event, CreateEventCommand>().ReverseMap();
        CreateMap<Event, UpdateEventCommand>().ReverseMap();
        CreateMap<Event, EventVm>().ReverseMap();
    }
}