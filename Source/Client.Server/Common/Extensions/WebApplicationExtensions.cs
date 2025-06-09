using Erdmier.GigHero.Domain.ApplicationUserAggregate;

using FastEndpoints;

namespace Erdmier.GigHero.Client.Server.Common.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        app.MapIdentityApi<ApplicationUser>();

        app.UseFastEndpoints();

        if (app.Environment.IsDevelopment())
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
