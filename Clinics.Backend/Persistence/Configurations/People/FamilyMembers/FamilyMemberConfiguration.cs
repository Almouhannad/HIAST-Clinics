using Domain.Entities.People.FamilyMembers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.FamilyMembers;

internal class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
{
    public void Configure(EntityTypeBuilder<FamilyMember> builder)
    {
        builder.ToTable(nameof(FamilyMember));

        builder.Property(familyMember => familyMember.Id).ValueGeneratedOnAdd();

        builder.HasOne(familyMember => familyMember.Patient)
            .WithOne()
            .HasForeignKey<FamilyMember>(familyMember => familyMember.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}