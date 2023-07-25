using LawFirm.Application.Contracts.Persistence;
using LawFirm.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LawFirm.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LawFirmContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("LawFirmContext")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ICourtCaseRepository, CourtCaseRepository>();

        return services;
    }
}