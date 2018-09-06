using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.ReadOnly;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Services;
using Naitzel.Intranet.Domain.AdminLte.Services.Common;
using Naitzel.Intranet.Infra.Data.AdminLte.Repository;
using Naitzel.Intranet.Service.AdminLte.Validation;

namespace Naitzel.Intranet.Infra.CrossCutting.AdminLte.IoC
{
    public static class SetupMessage
    {
        public static void AddMessageService(this IServiceCollection services, IConfiguration configuration)
        {
            // Message Service
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IService<Message>, MessageService>();

            // Message Validation
            services.AddTransient<IMessageValidation, MessageValidation>();
            services.AddTransient<IValidation<Message>, MessageValidation>();

            // Message Repository
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IRepository<Message>, MessageRepository>();

            // Message Repository Read Only
            services.AddTransient<IMessageReadOnlyRepository, MessageRepository>();
            services.AddTransient<IReadOnlyRepository<Message>, MessageRepository>();
        }
    }
}