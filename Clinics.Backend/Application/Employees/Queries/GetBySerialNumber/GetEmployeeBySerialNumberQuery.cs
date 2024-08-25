using Application.Abstractions.CQRS.Queries;

namespace Application.Employees.Queries.GetBySerialNumber;

public class GetEmployeeBySerialNumberQuery : IQuery<GetEmployeeBySerialNumberResponse>
{
    public string SerialNumber { get; set; } = null!;
}
