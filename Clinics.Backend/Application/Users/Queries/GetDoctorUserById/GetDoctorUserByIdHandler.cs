using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Queries.GetDoctorUserById;

public class GetDoctorUserByIdHandler : IQueryHandler<GetDoctorUserByIdQuery, GetDoctorUserByIdResponse>
{
    #region CTOD DI
    private readonly IUserRepository _userRepository;

    public GetDoctorUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion
    public async Task<Result<GetDoctorUserByIdResponse>> Handle(GetDoctorUserByIdQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch doctor user from DB
        var doctorUserFromDbResult = await _userRepository.GetDoctorUserByIdAsync(request.Id);
        if (doctorUserFromDbResult.IsFailure)
            return Result.Failure<GetDoctorUserByIdResponse>(doctorUserFromDbResult.Error);
        #endregion

        #region 2. Generate response
        var response = GetDoctorUserByIdResponse.GetResponse(doctorUserFromDbResult.Value);
        if (response.IsFailure)
            return Result.Failure<GetDoctorUserByIdResponse>(response.Error);
        #endregion
    
        return Result.Success<GetDoctorUserByIdResponse>(response.Value);

    }
}
