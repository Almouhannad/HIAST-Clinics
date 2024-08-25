using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Employees.Queries.GetAvailable;

public class GetAvailableDoctorsHandler : IQueryHandler<GetAvailableDoctorsQuery, GetAvailableDoctorsResponse>
{
    #region CTOR DI
    private readonly IDoctorsRepository _doctorsRepository;

    public GetAvailableDoctorsHandler(IDoctorsRepository repository)
    {
        _doctorsRepository = repository;
    }
    #endregion

    public async Task<Result<GetAvailableDoctorsResponse>> Handle(GetAvailableDoctorsQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch data from persistence
        var doctorsFromPersistence = await _doctorsRepository.GetAvailableDoctors();
        if (doctorsFromPersistence.IsFailure)
            return Result.Failure<GetAvailableDoctorsResponse>(doctorsFromPersistence.Error);
        var doctors = doctorsFromPersistence.Value;
        #endregion

        return GetAvailableDoctorsResponse.GetResponse(doctors);
    }
}
