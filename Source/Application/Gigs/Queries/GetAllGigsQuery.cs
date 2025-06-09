using Erdmier.GigHero.Domain.GigAggregate;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed record GetAllGigsQuery(Guid UserId) : IQuery<List<Gig>>;
