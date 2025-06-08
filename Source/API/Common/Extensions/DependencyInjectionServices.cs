using Erdmier.GigHero.Domain.ApplicationUserAggregate;
using Erdmier.GigHero.Domain.ApplicationUserAggregate.Entities;
using Erdmier.GigHero.Persistence.Contexts;

using Microsoft.AspNetCore.Identity;

namespace Erdmier.GigHero.API.Common.Extensions;

public static class DependencyInjectionServices
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        => services.AddIdentityServices()
                   .AddMiddlewareServices(configuration, environment);

    // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-9.0
    private static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

        // services.AddAuthentication()
        //         .AddJwtBearer()
        //         .AddJwtBearer(authenticationScheme: "LocalAuthIssuer");

        services.AddAuthorizationBuilder();

        services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

        return services;
    }

    private static IServiceCollection AddMiddlewareServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        // services.AddFastEndpoints();

        // services.AddCors(options => options.AddPolicy(name: "wasm",
        //                                               policy => policy
        //                                                         .WithOrigins(origins:
        //                                                         [
        //                                                             configuration[key: "SystemUris:ApiUri"]!,
        //                                                             configuration[key: "SystemUris:WasmClientUri"]!
        //                                                         ])
        //                                                         .AllowAnyMethod()
        //                                                         .AllowAnyHeader()
        //                                                         .AllowCredentials()));

        services.AddEndpointsApiExplorer();

        return services;
    }
}
