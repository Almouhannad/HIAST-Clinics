using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Queries.GetAllReceptionistsUsers;

public class GetAllReceptionistUsersHandler : IQueryHandler<GetAllReceptionistUsersQuery, GetAllReceptionistUsersResponse>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;

    public GetAllReceptionistUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    public async Task<Result<GetAllReceptionistUsersResponse>> Handle(GetAllReceptionistUsersQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch users from DB
        var receptionistUsersFromDbResult = await _userRepository.GetAllReceptionistUsersAsync();
        if (receptionistUsersFromDbResult.IsFailure)
            return Result.Failure<GetAllReceptionistUsersResponse>(receptionistUsersFromDbResult.Error);
        #endregion

        #region 2. Generate response
        var response = GetAllReceptionistUsersResponse.GetResponse(receptionistUsersFromDbResult.Value);
        if (response.IsFailure)
            return Result.Failure<GetAllReceptionistUsersResponse>(response.Error);
        #endregion

        return Result.Success<GetAllReceptionistUsersResponse>(response.Value);
        // Or just return response.Value
    }
}
