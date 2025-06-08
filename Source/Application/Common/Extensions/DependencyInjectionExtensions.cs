using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace Erdmier.GigHero.Application.Common.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
