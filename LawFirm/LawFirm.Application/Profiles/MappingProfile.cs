using AutoMapper;
using LawFirm.Application.Features.Clients.Commands.CreateClient;
using LawFirm.Application.Features.Clients.Commands.UpdateClient;
using LawFirm.Application.Features.Clients.Queries.GetClientDetail;
using LawFirm.Application.Features.Clients.Queries.GetClientList;
using LawFirm.Domain.Entities;

namespace LawFirm.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientListVm>().ReverseMap();
        CreateMap<Client, CreateClientCommand>().ReverseMap();
        CreateMap<Client, ClientDetailVm>().ReverseMap();
        CreateMap<Client, CreateClientDto>().ReverseMap();
        CreateMap<Client, UpdateClientCommand>().ReverseMap();
    }
}