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

        return Result.Success();
    }
}
