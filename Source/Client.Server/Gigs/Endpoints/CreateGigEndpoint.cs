namespace Erdmier.GigHero.Client.Server.Gigs.Endpoints;

public sealed class CreateGigEndpoint : Endpoint<CreateGigRequest, Results<Created<CreateGigResponse>, InternalServerError<CreateGigResponse>>>
{
    private readonly IMapper<Gig, GigDto> _gigMapper;

    private readonly ISender _sender;

    public CreateGigEndpoint(IMapper<Gig, GigDto> gigMapper, ISender sender)
    {
        _gigMapper = gigMapper;
        _sender    = sender;
    }

    public override void Configure()
    {
        Post("/api/gigs");
    }

    public override async Task<Results<Created<CreateGigResponse>, InternalServerError<CreateGigResponse>>> ExecuteAsync(CreateGigRequest  request,
                                                                                                                         CancellationToken cancellationToken)
    {
        try
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            Gig? result = await _sender.Send(new CreateGigCommand(request.Name, userId, request.WebsiteUrl), cancellationToken);

            return result is null
                       ? TypedResults.InternalServerError(CreateGigResponse.Failure(errorMessage: "Unable to create Gig."))
                       : TypedResults.Created($"/api/gigs/{result.Id}", CreateGigResponse.Success(_gigMapper.MapToDto(result)));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return TypedResults.InternalServerError(CreateGigResponse.Failure(errorMessage: "Unable to create Gig."));
        }
    }
}
