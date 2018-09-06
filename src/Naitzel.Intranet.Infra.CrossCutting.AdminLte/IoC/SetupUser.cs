using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Infra.Security.AdminLte.Service;
using Naitzel.Intranet.Infra.Security.AdminLte.Validator;

namespace Naitzel.Intranet.Infra.CrossCutting.AdminLte.IoC
{
    public static class SetupUser
    {
        public static void AddUserService(this IServiceCollection services, IConfiguration configuration)
        {
            // User Service
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IService<User>, UserService>();
            services.AddTransient<IAccountService, AccountService>();

            // // User Validation
            services.AddTransient<IUserValidation, UserValidation>();
            services.AddTransient<IValidation<User>, UserValidation>();

            // User Repository
            // services.AddTransient<IUserRepository, UserRepository>();
            // services.AddTransient<IRepository<User>, UserRepository>();

            // User Repository Read Only
            // services.AddTransient<IUserReadOnlyRepository, UserRepository>();
            // services.AddTransient<IReadOnlyRepository<User>, UserRepository>();
        }
    }
}