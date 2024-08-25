using Application.Abstractions.CQRS.Queries;
using Domain.Entities.WaitingList;
using Domain.Repositories;
using Domain.Shared;
using static Application.WaitingList.Queries.GetAllWaitingListRecordsResponse;

namespace Application.WaitingList.Queries;

public class GetAllWaitingListRecordsQueryHandler : IQueryHandler<GetAllWaitingListRecordsQuery, GetAllWaitingListRecordsResponse>
{
    #region CTOR DI
    private readonly IWaitingListRepository _waitingListRepository;
    private readonly IPatientsRepository _petientsRepository;

    public GetAllWaitingListRecordsQueryHandler(IWaitingListRepository waitingListRepository, IPatientsRepository petientsRepository)
    {
        _waitingListRepository = waitingListRepository;
        _petientsRepository = petientsRepository;
    }
    #endregion

    public async Task<Result<GetAllWaitingListRecordsResponse>> Handle(GetAllWaitingListRecordsQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch all from persistence
        var fetchAllResult = await _waitingListRepository.GetAllAsync();
        if (fetchAllResult.IsFailure)
            return Result.Failure<GetAllWaitingListRecordsResponse>(fetchAllResult.Error);
        var allRecords = fetchAllResult.Value;
        #endregion

        #region 2. Generate response
        List<GetAllWaitingListRecordsResponseItem> response = [];
        foreach (WaitingListRecord record in allRecords)
        {
            var isEmployee = await _petientsRepository.IsEmployeeByIdAsync(record.PatientId);
            if (isEmployee.IsFailure)
                return Result.Failure<GetAllWaitingListRecordsResponse>(isEmployee.Error);

            var responseItem = new GetAllWaitingListRecordsResponseItem
            {
                Id = record.Id,
                PatientId = record.PatientId,
                IsEmployee = isEmployee.Value,
                FullName = record.Patient.PersonalInfo.FullName,
                ArrivalTime = record.ArrivalTime
            };
            response.Add(responseItem);
        }
        #endregion

        return Result.Success<GetAllWaitingListRecordsResponse>
            (new GetAllWaitingListRecordsResponse
            {
                WaitingListRecords = response
            });
    }
}
