using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Patients;

internal class PatientMedicineConfiguration : IEntityTypeConfiguration<PatientMedicine>
{
    public void Configure(EntityTypeBuilder<PatientMedicine> builder)
    {
        builder.ToTable(nameof(PatientMedicine));

        builder.HasOne(patientMedicine => patientMedicine.Patient)
            .WithMany(patient => patient.Medicines)
            .HasForeignKey(patientMedicine => patientMedicine.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(patientMedicine => patientMedicine.Medicine)
            .WithMany(medicine => medicine.Patients)
            .HasForeignKey(patientMedicine => patientMedicine.MedicineId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(patientMedicine =>
            new { patientMedicine.PatientId, patientMedicine.MedicineId })
            .IsUnique();
    }
}