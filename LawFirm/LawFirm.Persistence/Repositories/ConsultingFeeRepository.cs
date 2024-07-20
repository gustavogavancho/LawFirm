using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;

namespace LawFirm.Persistence.Repositories;

public class ConsultingFeeRepository : BaseRepository<ConsultingFee>, IConsultingFeeRepository
{
    public ConsultingFeeRepository(LawFirmContext dbContext) : base(dbContext) { }
}