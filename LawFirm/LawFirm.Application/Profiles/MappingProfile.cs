using AutoMapper;
using LawFirm.Application.Features.Cases.Commands.CreateCase;
using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Features.Clients.Commands.UpdateClient;
using LawFirm.Application.Features.Clients.Models;
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
        CreateMap<Case, CaseVm>().ReverseMap();
    }
}