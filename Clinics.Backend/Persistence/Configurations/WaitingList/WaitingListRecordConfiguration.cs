using Domain.Entities.WaitingList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.WaitingList;

internal class WaitingListRecordConfiguration : IEntityTypeConfiguration<WaitingListRecord>
{
    public void Configure(EntityTypeBuilder<WaitingListRecord> builder)
    {
        builder.ToTable(nameof(WaitingListRecord));

        builder.HasOne(waitingListRecord => waitingListRecord.Patient)
            .WithMany()
            .HasForeignKey(waitingListRecord => waitingListRecord.PatientId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}