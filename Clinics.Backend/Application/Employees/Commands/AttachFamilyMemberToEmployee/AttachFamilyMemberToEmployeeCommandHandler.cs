using Application.Abstractions.CQRS.Commands;
using Domain.Entities.People.Employees;
using Domain.Entities.People.FamilyMembers;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Employees.Commands.AttachFamilyMemberToEmployee;

public class AttachFamilyMemberToEmployeeCommandHandler : ICommandHandler<AttachFamilyMemberToEmployeeCommand>
{
    #region CTOR DI
    private readonly IEmployeesRepository _employeesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AttachFamilyMemberToEmployeeCommandHandler(IEmployeesRepository employeesRepository, IUnitOfWork unitOfWork)
    {
        _employeesRepository = employeesRepository;
        _unitOfWork = unitOfWork;
    }
    #endregion
    public async Task<Result> Handle(AttachFamilyMemberToEmployeeCommand request, CancellationToken cancellationToken)
    {
        #region 1. Create family member
        Result<FamilyMember> familyMemberResult
            = FamilyMember
            .Create(request.FirstName, request.MiddleName, request.LastName, request.DateOfBirth, request.Gender);
        if (familyMemberResult.IsFailure)
            return Result.Failure(familyMemberResult.Error);
        #endregion

        #region 2. Get employee by serial number
        Result<Employee> employeeResult = await _employeesRepository
            .GetEmployeeBySerialNumberAsync(request.EmployeeSerialNumber);
        if (employeeResult.IsFailure)
            return Result.Failure(employeeResult.Error);
        #endregion

        #region 3. Attach family member to employee
        Result attachFamilyMemberResult = employeeResult
            .Value
            .AddFamilyMember(familyMemberResult.Value, request.FamilyRole);
        if (attachFamilyMemberResult.IsFailure)
            return Result.Failure(attachFamilyMemberResult.Error);
        #endregion

        #region 4. Confirm update
        try
        {
            _employeesRepository.Update(employeeResult.Value);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception)
        {
            return Result.Failure(PersistenceErrors.UnableToCompleteTransaction);
        }

        return Result.Success();
        #endregion


    }
}
