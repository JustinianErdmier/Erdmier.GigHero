using Erdmier.GigHero.Domain.Gig.ValueObjects;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed record GetGigByIdQuery(GigId Id) : IQuery<Gig?>;
