using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Queries.GetAllDoctorUsers;

public class GetAllDoctorUsersHandler : IQueryHandler<GetAllDoctorUsersQuery, GetAllDoctorUsersResponse>
{
    #region Ctor DI
    private readonly IUserRepository _userRepository;

    public GetAllDoctorUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    public async Task<Result<GetAllDoctorUsersResponse>> Handle(GetAllDoctorUsersQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch users from DB
        var doctorUsersFromDbResult = await _userRepository.GetAllDoctorUsersAsync();
        if (doctorUsersFromDbResult.IsFailure)
            return Result.Failure<GetAllDoctorUsersResponse>(doctorUsersFromDbResult.Error);
        #endregion

        #region 2. Generate response
        var response = GetAllDoctorUsersResponse.GetResponse(doctorUsersFromDbResult.Value);
        if (response.IsFailure)
            return Result.Failure<GetAllDoctorUsersResponse>(response.Error);
        #endregion

        return Result.Success(response.Value);
    }
}
