using Erdmier.GigHero.Domain.AssignmentAggregate.ValueObjects;
using Erdmier.GigHero.Domain.Gig.ValueObjects;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Erdmier.GigHero.Persistence.Configurations;

public sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        ConfigureAssignmentsTable(builder);
        ConfigureAssignmentPaymentsTable(builder);
        ConfigureAssignmentTimeEntriesTable(builder);
    }

    private static void ConfigureAssignmentsTable(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable(name: "Assignments");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value, value => AssignmentId.Create(value));

        builder.Property(a => a.GigId)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => GigId.Create(value));

        builder.Property(a => a.Name)
               .HasMaxLength(maxLength: 50)
               .IsRequired();

        builder.Property(a => a.Uri)
               .HasMaxLength(maxLength: 256);

        builder.HasIndex(a => a.GigId);
    }

    private static void ConfigureAssignmentPaymentsTable(EntityTypeBuilder<Assignment> builder)
    {
        builder.OwnsMany(a => a.Payments,
                         pb =>
                         {
                             pb.ToTable(name: "AssignmentPayments");

                             pb.WithOwner()
                               .HasForeignKey("AssignmentId");

                             pb.HasKey("Id", "AssignmentId");

                             pb.Property(p => p.Id)
                               .HasColumnName(name: "AssignmentPaymentId")
                               .ValueGeneratedNever()
                               .HasConversion(id => id.Value,
                                              value => PaymentId.Create(value));

                             pb.Property(p => p.Actual)
                               .HasColumnType(typeName: "decimal(7, 2)")
                               .HasConversion(payment => payment.Amount,
                                              amount => ActualPayment.Create(amount));

                             pb.Property(p => p.Expected)
                               .HasColumnType(typeName: "decimal(7, 2)")
                               .HasConversion(payment => payment.Amount,
                                              amount => ExpectedPayment.Create(amount));

                             pb.Property(p => p.Status)
                               .HasMaxLength(maxLength: 26)
                               .HasConversion<string>();

                             pb.Property(p => p.StatusComment)
                               .HasMaxLength(maxLength: 500);
                         });

        builder.Metadata.FindNavigation(nameof(Assignment.Payments))
            !.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureAssignmentTimeEntriesTable(EntityTypeBuilder<Assignment> builder)
    {
        builder.OwnsMany(a => a.TimeEntries,
                         teb =>
                         {
                             teb.ToTable(name: "AssignmentTimeEntries");

                             teb.WithOwner()
                                .HasForeignKey("AssignmentId");

                             teb.HasKey("Id", "AssignmentId");

                             teb.Property(te => te.Id)
                                .HasColumnName(name: "AssignmentTimeEntryId")
                                .ValueGeneratedNever()
                                .HasConversion(id => id.Value, value => TimeEntryId.Create(value));

                             teb.Property(te => te.End)
                                .HasColumnType(typeName: "datetimeoffset")
                                .HasConversion(entry => entry == null ? DateTimeOffset.MinValue : entry.Time,
                                               time => time   != DateTimeOffset.MinValue ? TimeEntryEnd.Create(time) : null);

                             teb.Property(te => te.Start)
                                .HasColumnType(typeName: "datetimeoffset")
                                .HasConversion(entry => entry.Time,
                                               time => TimeEntryStart.Create(time));
                         });

        builder.Metadata.FindNavigation(nameof(Assignment.TimeEntries))
            !.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
