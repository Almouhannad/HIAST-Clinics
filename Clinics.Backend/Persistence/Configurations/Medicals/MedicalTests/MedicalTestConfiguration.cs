using Domain.Entities.Medicals.MedicalTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Medicals.MedicalTests;

internal class MedicalTestConfiguration : IEntityTypeConfiguration<MedicalTest>
{
    public void Configure(EntityTypeBuilder<MedicalTest> builder)
    {
        builder.ToTable(nameof(MedicalTest));

        builder.Property(medicalTest => medicalTest.Description).HasMaxLength(250);

        builder.Property(medicalTest => medicalTest.Name).HasMaxLength(50);
    }
}