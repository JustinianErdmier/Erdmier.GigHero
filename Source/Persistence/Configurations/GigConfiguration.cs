using Erdmier.GigHero.Domain.GigAggregate;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erdmier.GigHero.Persistence.Configurations;

public sealed class GigConfiguration : IEntityTypeConfiguration<Gig>
{
    public void Configure(EntityTypeBuilder<Gig> builder)
    {
        ConfigureGigTable(builder);
        ConfigureGigAssignmentIdsTable(builder);
    }

    private static void ConfigureGigTable(EntityTypeBuilder<Gig> builder)
    {
        builder.ToTable(name: "Gigs");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => GigId.Create(value));

        builder.Property(g => g.Name)
               .HasMaxLength(maxLength: 50)
               .IsRequired();

        builder.Property(g => g.WebsiteUrl)
               .HasMaxLength(maxLength: 256);

        builder.HasIndex(g => g.UserId);
    }

    private static void ConfigureGigAssignmentIdsTable(EntityTypeBuilder<Gig> builder)
    {
        builder.OwnsMany(g => g.AssignmentIds,
                         aib =>
                         {
                             aib.ToTable(name: "GigAssignmentIds");

                             aib.WithOwner()
                                .HasForeignKey("GigId");

                             aib.HasKey("Id");

                             aib.Property(ai => ai.Value)
                                .HasColumnName(name: "AssignmentId");
                         });

        builder.Metadata.FindNavigation(nameof(Gig.AssignmentIds))
            !.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
