using Application.Abstractions.CQRS.Commands;
using Domain.Entities.WaitingList;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.WaitingList.Commands.CreateWaitingListRecord;

public class CreateWaitingListRecordHandler : CommandHandlerBase<CreateWaitingListRecordCommand>
{
    #region CTOR DI
    private readonly IEmployeesRepository _employeesRepository;
    private readonly IWaitingListRepository _waitingListRepository;
    public CreateWaitingListRecordHandler(IUnitOfWork unitOfWork, IWaitingListRepository waitingListRepository, IEmployeesRepository employeesRepository) : base(unitOfWork)
    {
        _waitingListRepository = waitingListRepository;
        _employeesRepository = employeesRepository;
    }
    #endregion


    public override async Task<Result> HandleHelper(CreateWaitingListRecordCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch employee from persistence
        var employeeFromPersistenceResult = await _employeesRepository.GetEmployeeBySerialNumberAsync(request.SerialNumber);
        if (employeeFromPersistenceResult.IsFailure)
            return Result.Failure(employeeFromPersistenceResult.Error);
        var employee = employeeFromPersistenceResult.Value;
        #endregion

        #region 2. Check duplicate
        var duplicateResult = await _waitingListRepository.IsEmployeeInWaitingListAsync(request.SerialNumber);
        if (duplicateResult.IsFailure)
            return Result.Failure(duplicateResult.Error);

        if (duplicateResult.Value)
            return Result.Failure(DomainErrors.PatientAlreadyInWaitingList);
        #endregion

        #region 3. Create waiting list record
        var waitingListRecordResult = WaitingListRecord.Create(employee.Id);
        if (waitingListRecordResult.IsFailure)
            return Result.Failure(waitingListRecordResult.Error);
        var waitingListRecord = waitingListRecordResult.Value;
        #endregion

        #region 4. save changes
        var saveChangesResult = await _waitingListRepository.CreateAsync(waitingListRecord);
        if (saveChangesResult.IsFailure)
            return Result.Failure(saveChangesResult.Error);
        #endregion

        return Result.Success();
    }
}
