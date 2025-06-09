WebApplication.CreateBuilder(args)
              .ConfigureServices()
              .Build()
              .ConfigureMiddleware()
              .Run();
