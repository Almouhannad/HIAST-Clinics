using Domain.Entities.People.Shared.GenderValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Shared;

// TODO: Seed database with initial values from GenderValues
internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable(nameof(Gender));
        builder.Property(gender => gender.Id).ValueGeneratedNever();

        builder.Property(gender => gender.Name).HasMaxLength(50);

    }
}