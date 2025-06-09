using Erdmier.GigHero.Application.Gigs.Queries;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

using FastEndpoints;

using Mediator;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Erdmier.GigHero.Client.Server.Gigs.Endpoints;

public sealed class GetGigByIdEndpoint : Endpoint<EmptyRequest, Results<Ok<GetGigByIdResponse>, NotFound<GetGigByIdResponse>, InternalServerError<GetGigByIdResponse>>>
{
    private readonly IMapper<Gig, GigDto> _gigMapper;

    private readonly ISender _sender;

    public GetGigByIdEndpoint(IMapper<Gig, GigDto> gigMapper, ISender sender)
    {
        _gigMapper = gigMapper;
        _sender    = sender;
    }

    public override void Configure()
    {
        Get("/api/gigs/{id:guid}");
    }

    public override async Task<Results<Ok<GetGigByIdResponse>, NotFound<GetGigByIdResponse>, InternalServerError<GetGigByIdResponse>>>
        ExecuteAsync(EmptyRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Guid id = Route<Guid>(paramName: "id");

            Gig? result = await _sender.Send(new GetGigByIdQuery(GigId.Create(id)), cancellationToken);

            return result is null
                       ? TypedResults.NotFound(GetGigByIdResponse.Failure(errorMessage: "Gig not found."))
                       : TypedResults.Ok(GetGigByIdResponse.Success(_gigMapper.MapToDto(result)));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return TypedResults.InternalServerError(GetGigByIdResponse.Failure(errorMessage: "Unable to get Gig."));
        }
    }
}
