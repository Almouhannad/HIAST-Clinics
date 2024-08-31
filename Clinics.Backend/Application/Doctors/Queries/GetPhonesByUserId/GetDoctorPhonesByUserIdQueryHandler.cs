using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Doctors.Queries.GetPhonesByUserId;

public class GetDoctorPhonesByUserIdQueryHandler : IQueryHandler<GetDoctorPhonesByUserIdQuery, GetDoctorPhonesByUserIdResponse>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;

    public GetDoctorPhonesByUserIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion
    public async Task<Result<GetDoctorPhonesByUserIdResponse>> Handle(GetDoctorPhonesByUserIdQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch doctor from persistence
        var doctorFromPersistenceResult = await _userRepository
            .GetDoctorByDoctorUserIdAsync(request.DoctorUserId);
        if (doctorFromPersistenceResult.IsFailure)
            return Result.Failure<GetDoctorPhonesByUserIdResponse>(doctorFromPersistenceResult.Error);
        var doctor = doctorFromPersistenceResult.Value;
        #endregion

        // Generate response
        return Result.Success<GetDoctorPhonesByUserIdResponse>(
            GetDoctorPhonesByUserIdResponse.GetResponse(doctor));
    }
}
