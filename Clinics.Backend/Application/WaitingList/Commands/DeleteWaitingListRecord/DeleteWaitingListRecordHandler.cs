using Application.Abstractions.CQRS.Commands;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.WaitingList.Commands.DeleteWaitingListRecord;

public class DeleteWaitingListRecordHandler : CommandHandlerBase<DeleteWaitingListRecordCommand>
{
    #region CTOR DI
    private readonly IWaitingListRepository _waitingListRepository;
    public DeleteWaitingListRecordHandler(IUnitOfWork unitOfWork, IWaitingListRepository waitingListRepository) : base(unitOfWork)
    {
        _waitingListRepository = waitingListRepository;
    }
    #endregion


    public override async Task<Result> HandleHelper(DeleteWaitingListRecordCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch from persistence
        var recordFromPersistenceResult = await _waitingListRepository.GetByIdAsync(request.Id);
        if (recordFromPersistenceResult.IsFailure)
            return Result.Failure(recordFromPersistenceResult.Error);
        var record = recordFromPersistenceResult.Value;
        #endregion

        #region 2. Perform delete
        var deleteResult = await _waitingListRepository.DeleteAsync(record);
        if (deleteResult.IsFailure)
            return Result.Failure(deleteResult.Error);
        #endregion

        return Result.Success();
    }
}
