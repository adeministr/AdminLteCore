using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;
using Naitzel.Intranet.Domain.AdminLte.Services.Common;
using Naitzel.Intranet.Infra.Data.AdminLte;

namespace Naitzel.Intranet.Infra.CrossCutting.AdminLte.IoC
{
    public static class SetupService
    {
        public static void AddDefaultService(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            services.AddDbContext<AdminLteContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));

            // Interface Repository and Service
            services.AddTransient(typeof(IReadOnlyService<>), typeof(ReadOnlyService<>));
            services.AddTransient(typeof(IService<>), typeof(Service<>));
        }
    }
}