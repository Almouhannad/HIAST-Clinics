using Domain.Entities.Visits.Relations.VisitMedicalImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Visits;

internal class VisitMedicalImageConfiguration : IEntityTypeConfiguration<VisitMedicalImage>
{
    public void Configure(EntityTypeBuilder<VisitMedicalImage> builder)
    {
        builder.ToTable(nameof(VisitMedicalImage));

        builder.Property(visitMedicalImage => visitMedicalImage.Result)
            .HasMaxLength(250);

        builder.HasOne(visitMedicalImage => visitMedicalImage.Visit)
            .WithMany(visit => visit.MedicalImages)
            .HasForeignKey(visitMedicalImage => visitMedicalImage.VisitId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(visitMedicalImage => visitMedicalImage.MedicalImage)
            .WithMany()
            .HasForeignKey(visitMedicalImage => visitMedicalImage.MedicalImageId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(visitMedicalImage =>
            new { visitMedicalImage.VisitId, visitMedicalImage.MedicalImageId })
            .IsUnique();
    }
}