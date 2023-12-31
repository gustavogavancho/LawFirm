﻿using AutoMapper;
using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;

namespace LawFirm.App.Profiles;

public class Mappings : Profile
{
	public Mappings()
	{
		CreateMap<UserListViewModel, ApplicationUser>().ReverseMap();
		CreateMap<ChangePasswordViewModel, ChangePasswordRequest>().ReverseMap();

        CreateMap<CreateClientCommand, ClientVm>().ReverseMap();
		CreateMap<UpdateClientCommand, ClientVm>().ReverseMap();

		CreateMap<CreateCaseCommand, CaseVm>().ReverseMap();
        CreateMap<UpdateCaseCommand, CaseVm>().ReverseMap();

		CreateMap<CreateEventCommand, EventVm>().ReverseMap();
		CreateMap<UpdateEventCommand, EventVm>().ReverseMap();
    }
}