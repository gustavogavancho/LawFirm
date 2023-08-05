using AutoMapper;
using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;

namespace LawFirm.App.Profiles;

public class Mappings : Profile
{
	public Mappings()
	{
		CreateMap<ClientViewModel, ClientDetailVm>().ReverseMap();
		CreateMap<ClientViewModel, ClientListVm>().ReverseMap();
	}
}