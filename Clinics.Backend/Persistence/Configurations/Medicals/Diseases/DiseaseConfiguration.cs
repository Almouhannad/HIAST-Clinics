using Domain.Entities.Medicals.Diseases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Medicals.Diseases;

internal class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.ToTable(nameof(Disease));

        builder.Property(disease => disease.Name).HasMaxLength(50);
    }
}