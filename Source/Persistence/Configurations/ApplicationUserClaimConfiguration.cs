using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erdmier.GigHero.Persistence.Configurations;

public sealed class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder.ToTable(name: "ApplicationUserClaims");

        builder.HasKey(auc => auc.Id);
    }
}
