using System.Security.Claims;

using Erdmier.GigHero.API.Common.Extensions;
using Erdmier.GigHero.Application.Common.Extensions;
using Erdmier.GigHero.Application.Gigs.Commands;
using Erdmier.GigHero.Application.Gigs.Queries;
using Erdmier.GigHero.Client.Contracts.Common.Extensions;
using Erdmier.GigHero.Client.Contracts.Gigs.Models.Requests;
using Erdmier.GigHero.Domain.Gig;
using Erdmier.GigHero.Domain.Gig.ValueObjects;
using Erdmier.GigHero.Persistence.Common.Extensions;

using Mediator;

using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Environment.EnvironmentName);

builder.Services.AddApi(builder.Configuration, builder.Environment)
       .AddClientShared()
       .AddApplication()
       .AddPersistence(builder.Configuration, builder.Environment);

WebApplication app = builder.Build()
                            .ConfigureMiddleware(builder.Environment);

// TODO: Need to create a request object to wrap the name and websiteUrl and then use [FromBody]
// https://github.com/dotnet/aspnetcore/blob/main/src/Identity/Core/src/IdentityApiEndpointRouteBuilderExtensions.cs
app.MapPost(pattern: "/gigs/",
            async ([ FromBody ] CreateGigRequest request, ClaimsPrincipal user, ISender sender, CancellationToken cancellationToken) =>
            {
                Guid userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

                CreateGigCommand command = new(request.Name, userId, request.WebsiteUrl);

                Gig? response = await sender.Send(command, cancellationToken);

                return response is null ? Results.UnprocessableEntity() : Results.Created($"/gigs/{response.Id}", response);
            })
   .RequireAuthorization();

app.MapGet(pattern: "/gigs/{id:guid}",
           async (Guid id, ISender sender, CancellationToken cancellation) =>
           {
               Gig? response = await sender.Send(new GetGigByIdQuery(GigId.Create(id)), cancellation);

               return response is null ? Results.NotFound() : Results.Ok(response);
           })
   .RequireAuthorization();

app.MapGet(pattern: "/gigs/",
           async (ClaimsPrincipal user, ISender sender, CancellationToken cancellation) =>
           {
               Guid userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

               List<Gig> gigs = await sender.Send(new GetAllGigsQuery(userId), cancellation);

               return Results.Ok(gigs);
           })
   .RequireAuthorization();

app.Run();
