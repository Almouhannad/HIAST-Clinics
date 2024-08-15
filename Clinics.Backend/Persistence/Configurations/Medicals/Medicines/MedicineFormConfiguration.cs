using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Medicals.Medicines;

// TODO: Seed database with initial values from MedicineFormValues
internal class MedicineFormConfiguration : IEntityTypeConfiguration<MedicineForm>
{
    public void Configure(EntityTypeBuilder<MedicineForm> builder)
    {
        builder.ToTable(nameof(MedicineForm));
        builder.Property(medicineForm => medicineForm.Id).ValueGeneratedNever();

        builder.Property(medicineForm => medicineForm.Name).HasMaxLength(50);

    }
}