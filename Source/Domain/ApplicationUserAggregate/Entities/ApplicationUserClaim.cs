using Microsoft.AspNetCore.Identity;

namespace Erdmier.GigHero.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser User { get; set; } = null!;
}
