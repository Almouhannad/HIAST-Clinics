using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Employees;

internal class EmployeeFamilyMemberConfiguration : IEntityTypeConfiguration<EmployeeFamilyMember>
{
    public void Configure(EntityTypeBuilder<EmployeeFamilyMember> builder)
    {
        builder.ToTable(nameof(EmployeeFamilyMember));

        builder.HasOne(employeeFamilyMember => employeeFamilyMember.Role)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(employeeFamilyMember => employeeFamilyMember.FamilyMember)
            .WithMany()
            .HasForeignKey(employeeFamilyMember => employeeFamilyMember.FamilyMemberId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(employeeFamilyMember => employeeFamilyMember.Employee)
            .WithMany(employee => employee.FamilyMembers)
            .HasForeignKey(employeeFamilyMember => employeeFamilyMember.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}