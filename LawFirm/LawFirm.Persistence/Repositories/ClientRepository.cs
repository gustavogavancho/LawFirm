using LawFirm.Application.Contracts.Persistence;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(LawFirmContext dbContext) : base(dbContext) { }

    public async Task<List<Client>> FindCliendBySearchTerm(string searchTerm)
    {
        var isNumber = long.TryParse(searchTerm, out var number);

        var clients = !isNumber ? await _dbContext.Client.Where(x => x.FirstName.ToLower().Contains(searchTerm.ToLower()) || x.LastName.ToLower().Contains(searchTerm.ToLower()) || x.BusinessName.ToLower().Contains(searchTerm.ToLower()) ||x.Representative.ToLower().Contains(searchTerm.ToLower())).ToListAsync()
                       : await _dbContext.Client.Where(x => x.Nit == number).AsNoTracking().ToListAsync();

        return clients;
    }

    public async Task<List<Client>> GetLastestClients()
    {
        var clients = await _dbContext.Client.OrderByDescending(x => x.CreatedDate).Take(4).AsNoTracking().ToListAsync();

        return clients;
    }
}