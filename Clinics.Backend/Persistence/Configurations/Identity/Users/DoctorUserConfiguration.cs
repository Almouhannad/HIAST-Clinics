using Domain.Entities.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Identity.Users;

public class DoctorUserConfiguration : IEntityTypeConfiguration<DoctorUser>
{
    public void Configure(EntityTypeBuilder<DoctorUser> builder)
    {
        builder.ToTable(nameof(DoctorUser));

        builder.Property(doctorUser => doctorUser.Id).ValueGeneratedOnAdd();

        builder.HasOne(doctorUser => doctorUser.User)
            .WithOne()
            .HasForeignKey<DoctorUser>(doctorUser => doctorUser.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(doctorUser => doctorUser.Doctor)
            .WithOne()
            .HasForeignKey<DoctorUser>("DoctorId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
