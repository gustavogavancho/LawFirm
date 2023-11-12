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
        //TODO: Remove sensitive login
        services.AddDbContext<LawFirmContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("LawFirmContext"))
            .EnableSensitiveDataLogging());

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientCaseRepository, ClientCaseRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ICaseRepository, CaseRepository>();
        services.AddScoped<ICounterPartRepository, CounterPartRepository>();

        return services;
    }
}