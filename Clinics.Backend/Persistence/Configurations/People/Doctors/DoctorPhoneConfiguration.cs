using Domain.Entities.People.Doctors.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Doctors;

internal class DoctorPhoneConfiguration : IEntityTypeConfiguration<DoctorPhone>
{
    public void Configure(EntityTypeBuilder<DoctorPhone> builder)
    {
        builder.ToTable(nameof(DoctorPhone));

        builder.Property(doctorPhone => doctorPhone.Name).HasMaxLength(50);

        builder.Property(doctorPhone => doctorPhone.Phone).HasMaxLength(20);

        builder.HasIndex(doctorPhone => doctorPhone.Phone).IsUnique();
    }
}