using Application.Abstractions.CQRS.Commands;
using Domain.Entities.People.Employees;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Employees.Commands.Create;

public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
{
    #region CTOR DI
    private readonly IEmployeesRepository _employeesRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateEmployeeCommandHandler(IEmployeesRepository employeesRepository, IUnitOfWork unitOfWork)
    {
        _employeesRepository = employeesRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
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


        #region Check existed serial number
        Result<Employee> existedResult = await _employeesRepository.GetEmployeeBySerialNumberAsync(request.SerialNumber);
        if (existedResult.IsSuccess)
            return Result.Failure(DomainErrors.EmployeeAlreadyExist);
        #endregion


        try
        {
            _employeesRepository.Create(employeeResult.Value);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception exp)
        {
            // For debugging
            //return Result.Failure(new Error("Persistence.UnableToSaveTransaction", exp.Message));

            // For deployment
            return Result.Failure(Domain.Errors.PersistenceErrors.UnableToCompleteTransaction);
        }

        return Result.Success();
    }
}
