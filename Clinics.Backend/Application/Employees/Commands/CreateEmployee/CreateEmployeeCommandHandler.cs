using Application.Abstractions.CQRS.Commands;
using Domain.Entities.People.Employees;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler : CommandHandlerBase<CreateEmployeeCommand>
{
    #region CTOR DI
    private readonly IEmployeesRepository _employeesRepository;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeesRepository employeesRepository) : base(unitOfWork)
    {
        _employeesRepository = employeesRepository;
    }

    #endregion

    public override async Task<Result> HandleHelper(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {

        #region 1. Create employee
        Result<Employee> employeeResult =
            Employee
            .Create(
                request.FirstName, request.MiddleName, request.LastName,

                request.DateOfBirth, request.Gender, request.SerialNumber, request.CenterStatus, false,

                request.StartDate, request.AcademicQualification, request.WorkPhone, request.Location, request.Specialization,
                request.JobStatus
                );
        if (employeeResult.IsFailure)
            return Result.Failure(employeeResult.Error);
        #endregion

        #region 2. Check existed serial number
        Result<Employee> existedResult = await _employeesRepository.GetEmployeeBySerialNumberAsync(request.SerialNumber);
        if (existedResult.IsSuccess)
            return Result.Failure(DomainErrors.EmployeeAlreadyExist);
        #endregion

        #region 3. Add to DB
        var createResult = await _employeesRepository.CreateAsync(employeeResult.Value);
        if (createResult.IsFailure)
            return Result.Failure(createResult.Error);
        #endregion

        return Result.Success();
    }
}
