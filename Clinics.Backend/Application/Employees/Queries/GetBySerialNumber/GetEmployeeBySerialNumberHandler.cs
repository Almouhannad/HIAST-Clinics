using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Employees.Queries.GetBySerialNumber;

public class GetEmployeeBySerialNumberHandler : IQueryHandler<GetEmployeeBySerialNumberQuery, GetEmployeeBySerialNumberResponse>
{
    #region CTOR DI
    private readonly IEmployeesRepository _employeesRepository;

    public GetEmployeeBySerialNumberHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }
    #endregion
    public async Task<Result<GetEmployeeBySerialNumberResponse>> Handle(GetEmployeeBySerialNumberQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch from persistence
        var employeeFromPersistenceResult = await _employeesRepository.GetEmployeeBySerialNumberAsync(request.SerialNumber);
        if (employeeFromPersistenceResult.IsFailure)
            return Result.Failure<GetEmployeeBySerialNumberResponse>(employeeFromPersistenceResult.Error);
        var employee = employeeFromPersistenceResult.Value;
        #endregion

        return Result.Success<GetEmployeeBySerialNumberResponse>
            (GetEmployeeBySerialNumberResponse.GetResponse(employee));
    }
}
