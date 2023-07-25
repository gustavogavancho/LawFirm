using LawFirm.Identity.Models;
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
}