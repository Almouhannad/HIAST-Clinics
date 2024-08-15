using Domain.Entities.WaitingList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.WaitingList;

internal class WaitingListRecordConfiguration : IEntityTypeConfiguration<WaitingListRecord>
{
    public void Configure(EntityTypeBuilder<WaitingListRecord> builder)
    {
        builder.ToTable(nameof(WaitingListRecord));

        builder.Property(waitingListRecord => waitingListRecord.IsServed)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(waitingListRecord => waitingListRecord.Patient)
            .WithMany()
            .HasForeignKey(waitingListRecord => waitingListRecord.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(waitingListRecord => waitingListRecord.Doctor)
            .WithMany()
            .HasForeignKey(waitingListRecord => waitingListRecord.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}