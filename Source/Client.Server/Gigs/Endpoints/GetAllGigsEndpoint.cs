using System.Security.Claims;

using Erdmier.GigHero.Application.Gigs.Queries;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.GigAggregate;

using FastEndpoints;

using Mediator;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Erdmier.GigHero.Client.Server.Gigs.Endpoints;

public sealed class GetAllGigsEndpoint : Endpoint<EmptyRequest, Results<Ok<GetAllGigsResponse>, InternalServerError<GetAllGigsResponse>>>
{
    private readonly IMapper<Gig, GigDto> _gigMapper;

    private readonly ISender _sender;

    public GetAllGigsEndpoint(IMapper<Gig, GigDto> gigMapper, ISender sender)
    {
        _gigMapper = gigMapper;
        _sender    = sender;
    }

    public override void Configure()
    {
        Get("/api/gigs");
    }

    public override async Task<Results<Ok<GetAllGigsResponse>, InternalServerError<GetAllGigsResponse>>> ExecuteAsync(EmptyRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            List<Gig> gigs = await _sender.Send(new GetAllGigsQuery(userId), cancellationToken);

            return TypedResults.Ok(GetAllGigsResponse.Success(gigs.Select(_gigMapper.MapToDto).ToList()));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return TypedResults.InternalServerError(GetAllGigsResponse.Failure(errorMessage: "Unable to get all Gigs."));
        }
    }
}
