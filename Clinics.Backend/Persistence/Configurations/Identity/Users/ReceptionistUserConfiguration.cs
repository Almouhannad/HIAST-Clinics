using Domain.Entities.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Identity.Users;

public class ReceptionistUserConfiguration : IEntityTypeConfiguration<ReceptionistUser>
{
    public void Configure(EntityTypeBuilder<ReceptionistUser> builder)
    {
        builder.ToTable(nameof(ReceptionistUser));

        builder.Property(receptionistUser => receptionistUser.Id).ValueGeneratedOnAdd();

        builder.HasOne(receptionistUser => receptionistUser.User)
            .WithOne()
            .HasForeignKey<ReceptionistUser>(receptionistUser => receptionistUser.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(receptionistUser => receptionistUser.PersonalInfo)
            .WithOne()
            .HasForeignKey<ReceptionistUser>("PersonalInfoId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
