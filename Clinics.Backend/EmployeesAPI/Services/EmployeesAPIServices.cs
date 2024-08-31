using Domain.Entities.People.Employees;
using Domain.Errors;
using Domain.Shared;
using EmployeesAPI.Configuration;
using EmployeesAPI.Contracts;
using System.Text.Json;

namespace EmployeesAPI.Services;

internal class EmployeesAPIServices : IEmployeesAPIServices
{
    #region Http client DI 
    private readonly HttpClient _httpClient;

    public EmployeesAPIServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    #endregion


    public async Task<Result<ICollection<Employee>>> GetAll()
    {
        try
        {
            // Get response
            var response = await _httpClient.GetAsync(APILink.Link);
            response.EnsureSuccessStatusCode();

            // Parse response
            var responseBody = await response.Content.ReadAsStringAsync();
            var employeesResponses = JsonSerializer.Deserialize<EmployeeResponse[]>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true } // id in Json, Id in contract class
                );

            List<Employee> employees = new();
            if (employeesResponses is not null)
            {
                foreach (var employeeResponse in employeesResponses)
                {
                    Result<Employee> employeeResult = employeeResponse.GetEmployee();
                    if (employeeResult.IsFailure)
                        return Result.Failure<ICollection<Employee>>(employeeResult.Error);
                    employees.Add(employeeResult.Value);
                }
                return employees;
            }
            else
            {
                return Result.Failure<ICollection<Employee>>(APIErrors.NoData);
            }

        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Employee>>(APIErrors.UnableToConnect);
        }
    }
}
