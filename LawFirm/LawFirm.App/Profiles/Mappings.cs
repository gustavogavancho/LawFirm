using AutoMapper;
using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;

namespace LawFirm.App.Profiles;

public class Mappings : Profile
{
	public Mappings()
	{
		CreateMap<ClientViewModel, ClientDetailVm>().ReverseMap();
		CreateMap<ClientViewModel, UpdateClientCommand>().ReverseMap();
        CreateMap<CreateClientViewModel, ClientDetailVm>().ReverseMap();
        CreateMap<ClientViewModel, CreateClientDto>().ReverseMap();
        CreateMap<CreateClientViewModel, CreateClientCommand>().ReverseMap();
        CreateMap<CreateClientViewModel, UpdateClientCommand>().ReverseMap();

        CreateMap<ClientViewModel, ClientListVm>().ReverseMap();
		CreateMap<UserListViewModel, ApplicationUser>().ReverseMap();
		CreateMap<ChangePasswordViewModel, ChangePasswordRequest>().ReverseMap();
	}
}