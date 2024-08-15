using Domain.Entities.Medicals.Hospitals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Medicals.Hospitals;

internal class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.ToTable(nameof(Hospital));

        builder.Property(hospital => hospital.Name).HasMaxLength(50);
    }
}