using Erdmier.GigHero.API.Common.Extensions;
using Erdmier.GigHero.Application.Common.Extensions;
using Erdmier.GigHero.Persistence.Common.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi(builder.Configuration, builder.Environment)
       .AddApplication()
       .AddPersistence(builder.Configuration, builder.Environment);

WebApplication app = builder.Build()
                            .ConfigureMiddleware(builder.Environment);

app.MapGet(pattern: "/auth/register",
           () => new
           {
               Message = "Hello World!"
           })
   .WithName(endpointName: "RegisterUser");

app.Run();
