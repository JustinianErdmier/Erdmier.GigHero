using Erdmier.GigHero.Domain.GigAggregate;

namespace Erdmier.GigHero.Application.Gigs.Commands;

public sealed record CreateGigCommand(string Name, Guid UserId, string? WebsiteUrl) : ICommand<Gig?>;
