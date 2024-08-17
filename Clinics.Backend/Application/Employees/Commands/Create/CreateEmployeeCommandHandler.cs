using Application.Abstractions.CQRS.Commands;
using Domain.Entities.People.Employees;
using Domain.Repositories;
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

    public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        #region Create new employee
        Employee employee;
        try
        {
            employee = Employee.Create(
                request.FirstName, request.MiddleName, request.LastName, // Personal info

                request.DateOfBirth, request.Gender, // Patient info

                request.SerialNumber, request.CenterStatus, false, // Employee info

                request.StartDate, request.AcademicQualification, request.WorkPhone, // additional
                request.Location, request.Specialization, request.JobStatus);
        }
        catch (Exception)
        {
            throw;
        }
        #endregion

        #region Add to DB
        try
        {
            _employeesRepository.Create(employee);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        #endregion

    }
}
