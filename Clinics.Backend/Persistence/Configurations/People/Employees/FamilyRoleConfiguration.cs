using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Employees;

// TODO: Seed database with initial values from FamilyRoleValues
internal class FamilyRoleConfiguration : IEntityTypeConfiguration<FamilyRole>
{
    public void Configure(EntityTypeBuilder<FamilyRole> builder)
    {
        builder.ToTable(nameof(FamilyRole));
        builder.Property(familyRole => familyRole.Id).ValueGeneratedNever();

        builder.Property(familyRole => familyRole.Name).HasMaxLength(50);
    }
}