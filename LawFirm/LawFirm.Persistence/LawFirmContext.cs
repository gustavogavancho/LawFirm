using LawFirm.Application.Contracts;
using LawFirm.Domain.Common;
using LawFirm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Persistence;

public class LawFirmContext : DbContext
{
    private readonly ILoggedInUserService? _loggedInUserService;

    public LawFirmContext(DbContextOptions<LawFirmContext> options) : base(options)
    {

    }

    public LawFirmContext(DbContextOptions<LawFirmContext> options, ILoggedInUserService loggedInUserService) : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    public DbSet<Client> Client { get; set; }
    public DbSet<CourtCase> CourtCase { get; set; }
    public DbSet<Event> Event { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}