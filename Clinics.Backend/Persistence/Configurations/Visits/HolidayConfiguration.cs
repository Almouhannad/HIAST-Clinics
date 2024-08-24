using Domain.Entities.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Visits;

public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
{
    public void Configure(EntityTypeBuilder<Holiday> builder)
    {
        builder.ToTable(nameof(Holiday));

        builder.Property(holiday => holiday.From).IsRequired();
        builder.Property(holiday => holiday.Duration).IsRequired();
    }
}
