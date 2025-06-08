using Microsoft.AspNetCore.Identity;

namespace Erdmier.GigHero.Domain.ApplicationUserAggregate.Entities;

public sealed class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser User { get; set; } = null!;
}
