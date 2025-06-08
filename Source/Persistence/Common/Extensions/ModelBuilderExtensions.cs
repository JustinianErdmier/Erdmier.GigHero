using Erdmier.GigHero.Persistence.Configurations;

namespace Erdmier.GigHero.Persistence.Common.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureApplicationUserAggregate(this ModelBuilder modelBuilder)
    {
        new ApplicationUserConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
        new ApplicationRoleConfiguration().Configure(modelBuilder.Entity<ApplicationRole>());
        new ApplicationUserRoleConfiguration().Configure(modelBuilder.Entity<ApplicationUserRole>());
        new ApplicationUserClaimConfiguration().Configure(modelBuilder.Entity<ApplicationUserClaim>());
        new ApplicationUserLoginConfiguration().Configure(modelBuilder.Entity<ApplicationUserLogin>());
        new ApplicationUserTokenConfiguration().Configure(modelBuilder.Entity<ApplicationUserToken>());
        new ApplicationRoleClaimConfiguration().Configure(modelBuilder.Entity<ApplicationRoleClaim>());
    }

    public static void ConfigureAssignmentAggregate(this ModelBuilder modelBuilder) => new AssignmentConfiguration().Configure(modelBuilder.Entity<Assignment>());

    public static void ConfigureGigAggregate(this ModelBuilder modelBuilder) => new GigConfiguration().Configure(modelBuilder.Entity<Gig>());
}
