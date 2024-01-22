using LawFirm.Application.Contracts.Infrastructure;
using LawFirm.Application.Models.Mail;
using LawFirm.Application.Models.Storage;
using LawFirm.Infrastructure.Email;
using LawFirm.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LawFirm.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.Configure<BlobStorageSettings>(configuration.GetSection("BlogStorageSettings"));

        services.AddTransient<IEmailService, EmailService>();

        services.AddSingleton<IStorageService, BlobStorageService>();

        return services;
    }
}