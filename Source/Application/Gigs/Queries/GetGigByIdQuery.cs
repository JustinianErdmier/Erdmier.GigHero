using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

using ErrorOr;

namespace Erdmier.GigHero.Application.Gigs.Queries;

public sealed record GetGigByIdQuery(GigId Id) : IQuery<ErrorOr<Gig>>;
