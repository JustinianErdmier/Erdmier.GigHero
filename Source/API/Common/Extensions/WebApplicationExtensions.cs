using Erdmier.GigHero.Domain.ApplicationUserAggregate;

namespace Erdmier.GigHero.API.Common.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureMiddleware(this WebApplication app, IWebHostEnvironment environment)
    {
        app.MapIdentityApi<ApplicationUser>();

        if (environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // app.UseCors(policyName: "wasm");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHttpsRedirection();

        return app;
    }
}
