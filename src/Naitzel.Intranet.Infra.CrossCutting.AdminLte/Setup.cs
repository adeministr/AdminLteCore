using System;
using System.Linq;
using System.Reflection;

using AutoMapper;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using Naitzel.Intranet.Infra.CrossCutting.AdminLte.IoC;
using Naitzel.Intranet.Infra.Security.AdminLte;

namespace Naitzel.Intranet.Infra.CrossCutting.AdminLte
{
    public static class Setup
    {
        public static void RegisterAdminLte(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultService(configuration);
            services.AddAdminLteSecurity(configuration);
        }

        public static void ConfigureAdminLte(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseAdminLteSecurity(serviceProvider);
        }

        /**
         *  Auto load Fluent Validator
         */
        public static void AutoLoadMvcAdminLte(this IMvcBuilder mvcBuilder, Assembly[] assemblys)
        {
            mvcBuilder.AddFluentValidation(config =>
            {
                foreach (var ass in assemblys) config.RegisterValidatorsFromAssembly(ass);
            });
        }

        /**
         *  Auto load Auto Mapper
         */
        public static void AutoLoadAdminLte(this IServiceCollection services, Assembly[] assemblys)
        {
            services.AddAutoMapper(op => op.AddProfiles(assemblys));
        }
    }
}