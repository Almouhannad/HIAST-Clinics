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
            .HasForeignKey(visit => visit.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(visit => visit.Hospital)
            .WithMany()
            .HasForeignKey(visit => visit.HospitalId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(visit => visit.Holiday)
            .WithOne()
            .HasForeignKey<Holiday>(holiday => holiday.VisitId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}