using LawFirm.Api;
using LawFirm.Identity;
using LawFirm.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("LawFirm API starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
     .WriteTo.Console()
     .ReadFrom.Configuration(context.Configuration),
     true);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.UseSerilogRequestLogging();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LawFirmContext>();
    var dbContext2 = scope.ServiceProvider.GetRequiredService<LawFirmIdentityContext>();
    dbContext.Database.Migrate(); // This will apply all pending migrations
    dbContext2.Database.Migrate(); // This will apply all pending migrations
}

app.Run();

public partial class Program { }