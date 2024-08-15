using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Doctors;

// TODO: Seed database with initial values from DoctorStatusValues
internal class DoctorStatusConfiguration : IEntityTypeConfiguration<DoctorStatus>
{
    public void Configure(EntityTypeBuilder<DoctorStatus> builder)
    {
        builder.ToTable(nameof(DoctorStatus));
        builder.Property(doctorStatus => doctorStatus.Id).ValueGeneratedNever();

        builder.Property(doctorStatus => doctorStatus.Name).HasMaxLength(50);

    }
}