using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Extension
{
    public static class ModelBuilderExtension
    {
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly.GetTypes().Where(x => !x.IsAbstract && x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
        }

        public static ModelBuilder ApplyDefaultConfiguration<T>(this ModelBuilder builder)
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;

            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityTypeConfiguration<>));

            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                    x.IsGenericMethod &&
                    x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                var entityBuilder = genericEntityMethod.Invoke(builder, null);
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new [] { entityBuilder });
            }

            return builder;
        }
    }
}