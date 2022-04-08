using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Test_Shop.Infrastructure.Interfaces.Mappings;

namespace Test_Shop.Infrastructure.Implementation.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var assembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .SingleOrDefault(asm => asm.GetName().Name == "Test-Shop.Application");

            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                                 ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] {this});

            }
        }
    }
}
