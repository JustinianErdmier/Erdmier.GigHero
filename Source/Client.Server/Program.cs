using Erdmier.GigHero.Client.Server.Common.Extensions;

WebApplication.CreateBuilder(args)
              .ConfigureServices()
              .Build()
              .ConfigureMiddleware()
              .Run();
