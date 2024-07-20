using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class ConsultingFeeDataService : BaseDataService, IConsultingFeeDataService
{
    private readonly IMapper mapper;

    public ConsultingFeeDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
    {
        this.mapper = mapper;
    }

    public async Task<ConsultingFeeVMPagingResponse> GetConsultingFees(int? pageNumber, int? pageSize)
    {
        var pagedClients = await _client.GetConsultingFeesAsync(pageNumber, pageSize);

        return pagedClients;
    }
}