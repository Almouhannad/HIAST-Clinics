using Domain.Entities.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Visits;

internal class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable(nameof(Visit));

        builder.Property(visit => visit.Diagnosis).HasMaxLength(250);

        builder.HasOne(visit => visit.Doctor)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(visit => visit.Hospital)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}