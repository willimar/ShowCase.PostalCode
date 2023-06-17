using DataCore.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowCase.PostalCode.Application.Interfaces;
using System.Reflection;
using static ShowCase.PostalCode.Application.Extensions.UserContextExtensions;

namespace ShowCase.PostalCode.Application.Setups
{
    public static class AppliocationSetup
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterUserContext(configuration);

            Assembly assembly = Assembly.GetExecutingAssembly();

            var allMappers = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IMapperEntity)));
            var allValidators = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i == typeof(IAppValidator)));
            var allMediators = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.Name.Contains("IRequestHandler")));

            foreach (var mapper in allMappers)
            {
                var contrato = mapper.GetInterfaces().FirstOrDefault(i => i.Name.Contains("IMapperProfile")) ?? throw new NullReferenceException();
                services.AddScoped(contrato, mapper);
            }

            foreach (var validator in allValidators)
            {
                var contrato = validator.GetInterfaces().FirstOrDefault(i => i.Name.Contains("IValidator")) ?? throw new NullReferenceException();
                services.AddScoped(contrato, validator);
            }

            foreach (var mediator in allMediators)
            {
                var interfaces = mediator.GetInterfaces();

                foreach (var contrato in interfaces)
                {
                    services.AddScoped(contrato, mediator);
                }
            }
        }
    }
}
