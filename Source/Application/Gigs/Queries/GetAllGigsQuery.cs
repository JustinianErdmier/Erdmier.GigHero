namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed record GetAllGigsQuery(Guid UserId) : IQuery<IList<Gig>>;
