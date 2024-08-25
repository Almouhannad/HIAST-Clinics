using Application.Abstractions.CQRS.Queries;
using Application.Employees.Queries.GetBySerialNumber;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Employees.Queries.GetById;

public class GetEmployeeByIdHandler : IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse>
{
    #region CTOR DI
    private readonly IEmployeesRepository _employeesRepository;

    public GetEmployeeByIdHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    #endregion

    public async Task<Result<GetEmployeeByIdResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch from persistence
        var employeeFromPersistenceResult = await _employeesRepository.GetByIdAsync(request.Id);
        if (employeeFromPersistenceResult.IsFailure)
            return Result.Failure<GetEmployeeByIdResponse>(employeeFromPersistenceResult.Error);
        var employee = employeeFromPersistenceResult.Value;
        #endregion

        return Result.Success<GetEmployeeByIdResponse>
            (GetEmployeeByIdResponse.GetResponse(employee));
    }
}
