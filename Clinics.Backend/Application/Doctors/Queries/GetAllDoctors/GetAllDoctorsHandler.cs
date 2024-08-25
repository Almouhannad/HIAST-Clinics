using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsHandler : IQueryHandler<GetAllDoctorsQuery, GetAllDoctorsResponse>
{
    #region CTOR DI
    private readonly IDoctorsRepository _doctorsRepository;

    public GetAllDoctorsHandler(IDoctorsRepository doctorsRepository)
    {
        _doctorsRepository = doctorsRepository;
    }
    #endregion
    public async Task<Result<GetAllDoctorsResponse>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch data from persistence
        var dataFromPersistenceResult = await _doctorsRepository.GetAllAsync();
        if (dataFromPersistenceResult.IsFailure)
            return Result.Failure<GetAllDoctorsResponse>(dataFromPersistenceResult.Error);
        var doctors = dataFromPersistenceResult.Value;
        #endregion

        return Result.Success<GetAllDoctorsResponse>(GetAllDoctorsResponse.GetResponse(doctors));
    }
}
