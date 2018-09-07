using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.ReadOnly;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Services;
using Naitzel.Intranet.Domain.AdminLte.Services.Common;
using Naitzel.Intranet.Infra.Data.AdminLte;
using Naitzel.Intranet.Infra.Data.AdminLte.Audits;
using Naitzel.Intranet.Infra.Data.AdminLte.Audits.Common;
using Naitzel.Intranet.Infra.Data.AdminLte.Repository;
using Naitzel.Intranet.Infra.Security.AdminLte.Service;
using Naitzel.Intranet.Infra.Security.AdminLte.Validator;
using Naitzel.Intranet.Service.AdminLte.Validation;

namespace Naitzel.Intranet.Infra.CrossCutting.AdminLte.IoC
{
    public static class SetupService
    {
        public static void AddDefaultService(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            services.AddDbContext<AdminLteContext>(
                optionsBuilder => optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    }
                )
            );

            // Interface Repository and Service
            services.AddTransient(typeof(IReadOnlyService<>), typeof(ReadOnlyService<>));
            services.AddTransient(typeof(IService<>), typeof(Service<>));
            services.AddTransient(typeof(IAuditService<>), typeof(AuditService<>));

            // Mensagem
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IMessageValidation, MessageValidation>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMessageReadOnlyRepository, MessageRepository>();
            services.AddTransient<IMessageAuditService, MessageAuditService>();

            // User
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserValidation, UserValidation>();
            services.AddTransient<IValidation<Domain.AdminLte.Entities.User>, UserValidation>();
        }
    }
}