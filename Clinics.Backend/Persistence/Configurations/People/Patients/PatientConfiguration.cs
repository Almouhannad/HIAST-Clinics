using Domain.Entities.People.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Patients;

internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(nameof(Patient));

        builder.Ignore(patient => patient.Age);

        builder.HasOne(patient => patient.PersonalInfo)
            .WithOne()
            .HasForeignKey<Patient>("PersonalInfoId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(patient => patient.Gender)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(patient => patient.Visits)
            .WithOne(visit => visit.Patient)
            .HasForeignKey(visit => visit.PatientId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}