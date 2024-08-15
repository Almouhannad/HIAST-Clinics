using Domain.Entities.Medicals.MedicalImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Medicals.MedicalImages;

internal class MedicalImageConfiguration : IEntityTypeConfiguration<MedicalImage>
{
    public void Configure(EntityTypeBuilder<MedicalImage> builder)
    {
        builder.ToTable(nameof(MedicalImage));

        builder.Property(medicalImage => medicalImage.Description).HasMaxLength(250);
        builder.Property(medicalImage => medicalImage.Name).HasMaxLength(50);
    }
}