using Erdmier.GigHero.Application.Common.Extensions;
using Erdmier.GigHero.Client.Shared.Common.Extensions;
using Erdmier.GigHero.Persistence.Common.Extensions;

namespace Erdmier.GigHero.Client.Server.Common.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApi(builder.Configuration, builder.Environment)
               .AddClientShared()
               .AddApplication()
               .AddPersistence(builder.Configuration, builder.Environment);

        return builder;
    }
}
