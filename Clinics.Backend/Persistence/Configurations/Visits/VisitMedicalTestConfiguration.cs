using Domain.Entities.Visits.Relations.VisitMedicalTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Visits;

internal class VisitMedicalTestConfiguration : IEntityTypeConfiguration<VisitMedicalTest>
{
    public void Configure(EntityTypeBuilder<VisitMedicalTest> builder)
    {
        builder.ToTable(nameof(VisitMedicalTest));

        builder.Property(visitMedicalTest => visitMedicalTest.Result)
            .HasMaxLength(250);

        builder.HasOne(visitMedicalTest => visitMedicalTest.Visit)
            .WithMany(visit => visit.MedicalTests)
            .HasForeignKey(visitMedicalTest => visitMedicalTest.VisitId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(visitMedicalTest => visitMedicalTest.MedicalTest)
            .WithMany()
            .HasForeignKey(visitMedicalTest => visitMedicalTest.MedicalTestId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(visitMedicalTest =>
            new { visitMedicalTest.VisitId, visitMedicalTest.MedicalTestId })
            .IsUnique();
    }
}