﻿using ErrorOr;

namespace Erdmier.GigHero.Client.Server.Gigs.Endpoints;

public sealed class GetGigByIdEndpoint
    : Endpoint<EmptyRequest, Results<Ok<GetGigByIdResponse>, NotFound<GetGigByIdResponse>, UnauthorizedHttpResult, InternalServerError<GetGigByIdResponse>>>
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

    public override async Task<Results<Ok<GetGigByIdResponse>, NotFound<GetGigByIdResponse>, UnauthorizedHttpResult, InternalServerError<GetGigByIdResponse>>>
        ExecuteAsync(EmptyRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Guid id = Route<Guid>(paramName: "id");

            ErrorOr<Gig> result = await _sender.Send(new GetGigByIdQuery(GigId.Create(id)), cancellationToken);

            if (!result.IsError
                && result.Value.UserId != User.GetId())
            {
                return TypedResults.Unauthorized();
            }

            return result.MatchFirst<Results<Ok<GetGigByIdResponse>,
                NotFound<GetGigByIdResponse>,
                UnauthorizedHttpResult,
                InternalServerError<GetGigByIdResponse>>>(value => TypedResults.Ok(GetGigByIdResponse.Success(_gigMapper.MapToDto(value))),
                                                          error => TypedResults.InternalServerError(GetGigByIdResponse.Failure(error.Description)));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return TypedResults.InternalServerError(GetGigByIdResponse.Failure(errorMessage: "Unable to get Gig."));
        }
    }
}
