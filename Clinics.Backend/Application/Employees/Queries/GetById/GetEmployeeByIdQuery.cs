using Application.Abstractions.CQRS.Queries;

namespace Application.Employees.Queries.GetById;

public class GetEmployeeByIdQuery : IQuery<GetEmployeeByIdResponse>
{
    public int Id { get; set; }
}
