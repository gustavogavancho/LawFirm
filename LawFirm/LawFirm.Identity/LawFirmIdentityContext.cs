using LawFirm.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawFirm.Identity;

public class LawFirmIdentityContext : IdentityDbContext<ApplicationUser>
{
    public LawFirmIdentityContext()
    {

    }

    public LawFirmIdentityContext(DbContextOptions<LawFirmIdentityContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var roleList = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Name = "User", NormalizedName = "USER"}
            };

        builder.Entity<IdentityRole>().HasData(roleList);

        var userList = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "ggavancholeon@gmail.com",
                    NormalizedEmail = "GGAVANCHOLEON@GMAIL.COM"
                }
            };

        builder.Entity<ApplicationUser>().HasData(userList);

        var hasher = new PasswordHasher<ApplicationUser>();
        userList[0].PasswordHash = hasher.HashPassword(userList[0], "Gustavo1@@");

        var userRoleList = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string> { UserId = userList[0].Id, RoleId = roleList[0].Id }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(userRoleList);
    }
}