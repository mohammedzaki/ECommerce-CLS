using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Data.Seeding
{
    public static class SeedingData
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role 
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                });
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            var SecurityStamp = Guid.NewGuid().ToString();
            var ConcurrencyStamp = Guid.NewGuid().ToString();
            var password = hasher.HashPassword(null, "!gfh$G89Tdsds");
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1,
                    UserName = "Admin",
                    NormalizedUserName = "Admin".ToUpper(),
                    Email = "admin@test.com",
                    NormalizedEmail = "admin@test.com".ToUpper(),
                    ConcurrencyStamp = ConcurrencyStamp,
                    SecurityStamp = SecurityStamp,
                    EmailConfirmed = true,
                    PhoneNumber = "0100000001",
                    PhoneNumberConfirmed = true,
                    PasswordHash = password
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole 
                {
                    RoleId = 1,
                    UserId = 1
                });
        }
    }
}
