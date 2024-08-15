using Domain.Entities.Visits.Relations.VisitMedicines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Visits;

internal class VisitMedicineConfiguration : IEntityTypeConfiguration<VisitMedicine>
{
    public void Configure(EntityTypeBuilder<VisitMedicine> builder)
    {
        builder.ToTable(nameof(VisitMedicine));

        builder.HasOne(visitMedicine => visitMedicine.Visit)
            .WithMany(visitMedicine => visitMedicine.Medicines)
            .HasForeignKey(visitMedicine => visitMedicine.VisitId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(visitMedicine => visitMedicine.Medicine)
            .WithMany()
            .HasForeignKey(visitMedicine => visitMedicine.MedicineId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(visitMedicine =>
            new { visitMedicine.VisitId, visitMedicine.MedicineId })
            .IsUnique();
    }
}