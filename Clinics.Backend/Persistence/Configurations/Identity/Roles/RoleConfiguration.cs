using Domain.Entities.Identity.UserRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Identity.Roles;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));

        builder.Property(role => role.Id).ValueGeneratedNever();

        builder.Property(role => role.Name)
            .HasMaxLength(50);

        builder.HasIndex(role => role.Name)
            .IsUnique();
    }
}
