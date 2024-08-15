using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Patients;

internal class PatientDiseaseConfiguration : IEntityTypeConfiguration<PatientDisease>
{
    public void Configure(EntityTypeBuilder<PatientDisease> builder)
    {
        builder.ToTable(nameof(PatientDisease));

        builder.HasOne(patientDisease => patientDisease.Patient)
            .WithMany(patient => patient.Diseases)
            .HasForeignKey(patientDisease => patientDisease.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(patientDisease => patientDisease.Disease)
            .WithMany(medicine => medicine.Patients)
            .HasForeignKey(patientDisease => patientDisease.DiseaseId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(patientDisease =>
            new { patientDisease.PatientId, patientDisease.DiseaseId })
            .IsUnique();
    }
}
