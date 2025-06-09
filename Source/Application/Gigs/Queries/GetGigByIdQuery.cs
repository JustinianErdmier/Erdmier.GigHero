using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed record GetGigByIdQuery(GigId Id) : IQuery<Gig?>;
