using Domain.Entities.People.Employees;
using EmployeesAPI.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace API.SeedDatabaseHelper;

public class SeedEmployeesHelper
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var employeesAPIServices = serviceScope.ServiceProvider.GetService<IEmployeesAPIServices>();
            var context = serviceScope.ServiceProvider.GetService<ClinicsDbContext>();

            if (employeesAPIServices is not null && context is not null)
            {
                var currentCount = (await context.Set<Employee>().ToListAsync()).Count;
                if (currentCount == 0)
                {
                    var employeesResult = await employeesAPIServices.GetAll();
                    if (employeesResult.IsSuccess)
                    {
                        var employees = employeesResult.Value;
                        foreach (var employee in employees)
                        {
                            context.Entry(employee.Patient.Gender).State = EntityState.Unchanged;
                            context.Set<Employee>().Add(employee);
                        }
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Error seeding employees: {employeesResult.Error}");
                    }
                }
            }
        }
    }
}