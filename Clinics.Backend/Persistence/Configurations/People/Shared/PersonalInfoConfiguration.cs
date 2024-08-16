using Domain.Entities.People.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Shared;

internal class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
{
    public void Configure(EntityTypeBuilder<PersonalInfo> builder)
    {
        builder.ToTable(nameof(PersonalInfo));

        builder.Ignore(personalInfo => personalInfo.FullName);

        builder.Property(personalInfo => personalInfo.FirstName).HasMaxLength(50);

        builder.Property(personalInfo => personalInfo.LastName).HasMaxLength(50);

        builder.Property(personalInfo => personalInfo.MiddleName).HasMaxLength(50);
    }
}
