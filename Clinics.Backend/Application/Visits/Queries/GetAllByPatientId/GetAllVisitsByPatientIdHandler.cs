using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Visits.Queries.GetAllByPatientId;

public class GetAllVisitsByPatientIdHandler : IQueryHandler<GetAllVisitsByPatientIdQuery, GetAllVisitsByPatientIdResponse>
{
    #region CTOR DI
    private readonly IVisitsRepository _visitsRepository;

    public GetAllVisitsByPatientIdHandler(IVisitsRepository visitsRepository)
    {
        _visitsRepository = visitsRepository;
    }
    #endregion

    public async Task<Result<GetAllVisitsByPatientIdResponse>> Handle(GetAllVisitsByPatientIdQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch data from persistence
        var visitsFromPersistenceResult = await _visitsRepository.GetAllByPatientIdAsync(request.PatientId);
        if (visitsFromPersistenceResult.IsFailure)
            return Result.Failure<GetAllVisitsByPatientIdResponse>(visitsFromPersistenceResult.Error);
        var visits = visitsFromPersistenceResult.Value;
        #endregion

        return GetAllVisitsByPatientIdResponse.GetResponse(visits);
    }
}
