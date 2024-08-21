using Domain.Entities.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Identity.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasIndex(user => user.UserName)
            .IsUnique();

        builder.HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey("RoleId");
    }
}
