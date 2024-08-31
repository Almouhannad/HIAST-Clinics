using Domain.Entities.Identity.UserRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Identity.Roles;

public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(nameof(UserRole));

        builder.Property(role => role.Id).ValueGeneratedNever();

        builder.Property(role => role.Name)
            .HasMaxLength(50);

        builder.HasIndex(role => role.Name)
            .IsUnique();
    }
}
