using System;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Infra.Data.AdminLte;
using Naitzel.Intranet.Infra.Security.AdminLte.Service;

namespace Naitzel.Intranet.Infra.Security.AdminLte
{
    public static class SetupSecurity
    {
        public static void AddAdminLteSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<AdminLteContext>()
                // .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, ClaimsPrincipalService>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        public static void UseAdminLteSecurity(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseAuthentication();
        }

    }
}