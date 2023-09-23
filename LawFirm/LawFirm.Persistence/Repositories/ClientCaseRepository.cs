using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;

namespace LawFirm.Persistence.Repositories;

public class ClientCaseRepository : BaseRepository<ClientCase>, IClientCaseRepository
{
    public ClientCaseRepository(LawFirmContext context)  : base(context)
    {
        
    }
}
