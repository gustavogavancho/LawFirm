using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IConsultingFeeDataService
{
    Task<ConsultingFeeVMPagingResponse> GetConsultingFees(int? pageNumber, int? pageSize);
}