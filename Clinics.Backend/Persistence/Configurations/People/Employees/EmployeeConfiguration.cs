using Domain.Entities.People.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Employees;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable(nameof(Employee));

        builder.Property(employee => employee.Id).ValueGeneratedOnAdd();

        builder.Property(employee => employee.CenterStatus).HasMaxLength(50);

        builder.Property(employee => employee.SerialNumber).HasMaxLength(20);

        builder.Property(employee => employee.IsMarried).HasDefaultValue(false)
            .IsRequired();

        builder.HasOne(employee => employee.AdditionalInfo)
            .WithOne()
            .HasForeignKey<Employee>("AdditionalInfoId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(employee => employee.Patient)
            .WithOne()
            .HasForeignKey<Employee>(employee => employee.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(employee => employee.RelatedEmployees)
            .WithMany(employee => employee.RelatedTo);
    }
}