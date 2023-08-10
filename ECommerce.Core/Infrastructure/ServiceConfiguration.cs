using ECommerce.Core.Data;
using ECommerce.Core.Services.Abstractions;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Core.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static void ConfigureECommerceAppServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            var connectionString = builder.Configuration.GetConnectionString("SqlServer");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ECommerce.Core"))
            );

            services
                .AddDefaultIdentity<User>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Register App Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddSession();
            // End of Register App Services
        }
    }
}
