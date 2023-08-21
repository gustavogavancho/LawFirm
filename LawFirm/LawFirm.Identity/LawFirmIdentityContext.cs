using LawFirm.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Identity;

public class LawFirmIdentityContext: IdentityDbContext<ApplicationUser>
{
    public LawFirmIdentityContext()
    {
        
    }

    public LawFirmIdentityContext(DbContextOptions<LawFirmIdentityContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            });
    }
}