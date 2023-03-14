using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
            var assembly = typeof(InjecaoDependencia).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
