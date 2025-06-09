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
            List<Gig> gigs = await _sender.Send(new GetAllGigsQuery(User.GetId()), cancellationToken);

            return TypedResults.Ok(GetAllGigsResponse.Success(gigs.Select(_gigMapper.MapToDto).ToList()));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return TypedResults.InternalServerError(GetAllGigsResponse.Failure(errorMessage: "Unable to get all Gigs."));
        }
    }
}
