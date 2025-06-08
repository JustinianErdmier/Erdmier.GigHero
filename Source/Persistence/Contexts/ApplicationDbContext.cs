using Erdmier.GigHero.Persistence.Common.Extensions;

namespace Erdmier.GigHero.Persistence.Contexts;

public sealed class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
{
    public const string ConnectionStringKey = "ConnectionStrings:ApplicationDbContext";

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Assignment> Assignments => Set<Assignment>();

    public DbSet<Gig> Gigs => Set<Gig>();

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureApplicationUserAggregate();
        modelBuilder.ConfigureAssignmentAggregate();
        modelBuilder.ConfigureGigAggregate();
    }
}
