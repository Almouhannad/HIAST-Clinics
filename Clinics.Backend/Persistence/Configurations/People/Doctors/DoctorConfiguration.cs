using Domain.Entities.People.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Doctors;

internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable(nameof(Doctor));

        builder.HasOne(doctor => doctor.PersonalInfo)
            .WithOne()
            .HasForeignKey<Doctor>("PersonalInfoId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(doctor => doctor.Status)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(doctor => doctor.Phones)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}