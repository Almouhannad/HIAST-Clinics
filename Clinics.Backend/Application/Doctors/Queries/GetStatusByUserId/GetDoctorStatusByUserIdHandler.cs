using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Doctors.Queries.GetStatusByUserId;

public class GetDoctorStatusByUserIdHandler : IQueryHandler<GetDoctorStatusByUserIdQuery, GetDoctorStatusByUserIdResponse>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;

    public GetDoctorStatusByUserIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    public async Task<Result<GetDoctorStatusByUserIdResponse>> Handle(GetDoctorStatusByUserIdQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch user
        var doctorUserFromPersistenceResult = await _userRepository.GetDoctorUserByIdAsync(request.UserId);
        if (doctorUserFromPersistenceResult.IsFailure)
            return Result.Failure<GetDoctorStatusByUserIdResponse>(doctorUserFromPersistenceResult.Error);
        var doctorUser = doctorUserFromPersistenceResult.Value;
        #endregion

        return Result.Success<GetDoctorStatusByUserIdResponse>(
            GetDoctorStatusByUserIdResponse.GetResponse(doctorUser.Doctor));
    }
}
