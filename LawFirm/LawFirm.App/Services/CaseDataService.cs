﻿using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class CaseDataService : BaseDataService, ICaseDataService
{
    private readonly IMapper _mapper;

    public CaseDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<CaseVm> CreateCase(CaseVm request, List<Guid> ids)
    {
        var responseMapped = _mapper.Map<CreateCaseCommand>(request);

        responseMapped.Ids = ids;

        var response = await _client.CreateCaseAsync(responseMapped);

        return response;
    }

    public async Task DeleteCase(Guid id)
    {
        await _client.DeleteCaseAsync(id);
    }

    public async Task<CaseVmPagingResponse> GetCases(int? pageNumber, int? pageSize)
    {
        var pagedCases = await _client.GetCasesAsync(pageNumber, pageSize);

        return pagedCases;
    }

    public async Task<CaseVm> GetCase(Guid id)
    {
        var response = await _client.GetCaseAsync(id);

        return response;
    }

    public async Task UpdateCase(CaseVm request, List<Guid> ids)
    {
        var responseMapped = _mapper.Map<UpdateCaseCommand>(request);

        responseMapped.Ids = ids;

        await _client.UpdateCaseAsync(responseMapped);
    }

    public async Task<ICollection<CaseVm>> FindCasesBySearchTerm(string searchTerm)
    {
        return await _client.FindCasesBySearchTermAsync(searchTerm);
    }

    public async Task<ICollection<CaseVm>> GetLatestCases()
    {
        var latestsCases = await _client.GetLatestsCasesAsync();

        return latestsCases;
    }
}