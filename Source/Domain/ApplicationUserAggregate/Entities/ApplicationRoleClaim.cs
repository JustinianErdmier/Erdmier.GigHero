using Microsoft.AspNetCore.Identity;

namespace Erdmier.GigHero.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationRole Role { get; set; } = null!;
}
