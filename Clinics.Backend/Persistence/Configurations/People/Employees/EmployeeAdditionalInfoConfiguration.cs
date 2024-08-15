using Domain.Entities.People.Employees.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.People.Employees;

internal class EmployeeAdditionalInfoConfiguration : IEntityTypeConfiguration<EmployeeAdditionalInfo>
{
    public void Configure(EntityTypeBuilder<EmployeeAdditionalInfo> builder)
    {
        builder.ToTable(nameof(EmployeeAdditionalInfo));

        builder.Property(employeeAdditionalInfo => employeeAdditionalInfo.AcademicQualification)
            .HasMaxLength(50);

        builder.Property(employeeAdditionalInfo => employeeAdditionalInfo.WorkPhone)
            .HasMaxLength(20);

        builder.Property(employeeAdditionalInfo => employeeAdditionalInfo.Location)
            .HasMaxLength(50);

        builder.Property(employeeAdditionalInfo => employeeAdditionalInfo.Specialization)
            .HasMaxLength(50);

        builder.Property(employeeAdditionalInfo => employeeAdditionalInfo.JobStatus)
            .HasMaxLength(50);

        builder.Property(e => e.ImageUrl)
            .HasMaxLength(150);
    }
}