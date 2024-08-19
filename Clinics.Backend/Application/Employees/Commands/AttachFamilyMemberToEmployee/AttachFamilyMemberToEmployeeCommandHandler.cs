using Application.Abstractions.CQRS.Commands;
using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;
using Domain.Entities.People.FamilyMembers;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Employees.Commands.AttachFamilyMemberToEmployee;

public class AttachFamilyMemberToEmployeeCommandHandler : CommandHandlerBase<AttachFamilyMemberToEmployeeCommand>
{
    #region CTOR DI
    private readonly IFamilyMembersRepository _familyMembersRepository;
    private readonly IEmployeeFamilyMembersRepository _employeeFamilyMembersRepository;
    private readonly IEmployeesRepository _employeesRepository;

    public AttachFamilyMemberToEmployeeCommandHandler(IUnitOfWork unitOfWork, IFamilyMembersRepository familyMembersRepository, IEmployeesRepository employeesRepository, IEmployeeFamilyMembersRepository employeeFamilyMembersRepository) : base(unitOfWork)
    {
        _familyMembersRepository = familyMembersRepository;
        _employeesRepository = employeesRepository;
        _employeeFamilyMembersRepository = employeeFamilyMembersRepository;
    }


    #endregion
    public override async Task<Result> HandleHelper(AttachFamilyMemberToEmployeeCommand request, CancellationToken cancellationToken)
    {
        #region 1. Create family member
        var createdFamilyMemberResult
            = FamilyMember
            .Create(
                request.FirstName, request.MiddleName,
                request.LastName, request.DateOfBirth, request.Gender
                );
        if (createdFamilyMemberResult.IsFailure)
            return Result.Failure(createdFamilyMemberResult.Error);
        #endregion

        #region 2. Add family member to DB
        var addedFamilyMemberResult
            = await _familyMembersRepository.CreateAsync(createdFamilyMemberResult.Value);

        if (addedFamilyMemberResult.IsFailure)
            return Result.Failure(addedFamilyMemberResult.Error);
        #endregion

        #region 3. Get employee from DB
        var employeeResult = await _employeesRepository.GetEmployeeBySerialNumberAsync(request.EmployeeSerialNumber);
        if (employeeResult.IsFailure)
            return Result.Failure(employeeResult.Error);
        #endregion

        #region 4. Create relation
        var employee = employeeResult.Value;
        var familyMember = addedFamilyMemberResult.Value;

        var employeeFamilyMemberResult = EmployeeFamilyMember.Create(employee, familyMember, request.FamilyRole);
        if (employeeFamilyMemberResult.IsFailure)
            return Result.Failure(employeeFamilyMemberResult.Error);
        #endregion

        #region 5. Add reltion to DB
        var addedEmployeeFamilyMemberResult
            = await _employeeFamilyMembersRepository.CreateAsync(employeeFamilyMemberResult.Value);

        if (addedEmployeeFamilyMemberResult.IsFailure)
            return Result.Failure(addedEmployeeFamilyMemberResult.Error);
        #endregion

        #region 6. Attach family member to employee
        var employeeFamilyMember = addedEmployeeFamilyMemberResult.Value;
        var attachResult = employee.AddFamilyMember(employeeFamilyMember);
        if (attachResult.IsFailure)
            return Result.Failure(attachResult.Error);
        #endregion

        #region 7. Confirm update
        var updateResult = await _employeesRepository.UpdateAsync(employee);
        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);
        #endregion

        return Result.Success();
    }
}
