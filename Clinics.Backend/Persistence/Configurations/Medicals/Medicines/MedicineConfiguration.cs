using Domain.Entities.Medicals.Medicines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Medicals.Medicines;

internal class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable(nameof(Medicine));

        builder.Property(e => e.Dosage).HasColumnType("numeric(9, 3)");

        builder.HasOne(medicine => medicine.MedicineForm)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}