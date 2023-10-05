using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HistorySpot.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Seed Roles (User,Admin,SuperAdmin)
            var adminRoleId = "a88f578d-0ec9-4aa9-8255-a131c56e1f7a";
            var superAdminRoleId = "83bd741c-6eb9-4973-ae07-acffacabfca2";
            var UserRoleId = "8f07d74b-0e19-467c-b75d-6029f4ccabcb";

            var roles = new List<IdentityRole>
            {

                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp=adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp=superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = UserRoleId,
                    ConcurrencyStamp=UserRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdminUser
            var superAdminId = "4b37fede-6f60-4613-9dec-82af2dba961a";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@historyspot.com",
                Email = "superadmin@historyspot.com",
                NormalizedEmail = "superadmin@historyspot.com".ToUpper(),
                NormalizedUserName = "superadmin@historyspot.com".ToUpper(),
                Id = superAdminId,
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin@123");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add all Roles to superAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                 new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                 new IdentityUserRole<string>
                {
                    RoleId = UserRoleId,
                    UserId = superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
