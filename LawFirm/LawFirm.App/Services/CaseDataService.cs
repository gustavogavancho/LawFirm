﻿using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class CaseDataService : BaseDataService, ICaseDataService
{
    public CaseDataService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
    }

    public async Task<CaseVm> CreateCase(CreateCaseCommand request)
    {
        var response = await _client.CreateCaseAsync(request);

        return response;
    }

    public async Task DeleteCase(Guid id)
    {
        await _client.DeleteCaseAsync(id);
    }

    public async Task<ICollection<CaseVm>> GetAllCases()
    {
        var response = await _client.GetCasesAsync();

        return response;
    }
}