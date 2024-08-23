using Application.Abstractions.CQRS.Commands;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Users.Commands.UpdateDoctorUser;

public class UpdateDoctorUserHandler : CommandHandlerBase<UpdateDoctorUserCommand>
{
    #region CROR DI
    private readonly IUserRepository _userRepository;
    public UpdateDoctorUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
    }

    #endregion

    public override async Task<Result> HandleHelper(UpdateDoctorUserCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch user from Db
        var userFromDbResult = await _userRepository.GetDoctorUserByIdAsync(request.Id);
        if (userFromDbResult.IsFailure)
            return Result.Failure(userFromDbResult.Error);
        var user = userFromDbResult.Value;
        #endregion

        #region 2. Check unique username
        if (user.User.UserName != request.UserName) // Unchanged user name, so just changing password
        {
            var uniqueUserNameResult = await _userRepository.IsUserNameAvailableAsunc(request.UserName);
            if (uniqueUserNameResult.IsFailure)
                return Result.Failure(uniqueUserNameResult.Error);
            if (uniqueUserNameResult.Value == false)
                return Result.Failure(IdentityErrors.TakenUserName);
        }


        #endregion

        #region 3. change username
        if (user.User.UserName != request.UserName) // Unchanged user name, so just changing password
        {
            var updateUserNameResult = await _userRepository.ChangeUserName(user.User, request.UserName);
            if (updateUserNameResult.IsFailure)
                return Result.Failure(updateUserNameResult.Error);
        }

        #endregion

        #region 4. Change password
        if (request.Password is not null)
        {
            var updatePasswordResult = await _userRepository.ChangePassword(user.User, request.Password);
            if (updatePasswordResult.IsFailure)
                return Result.Failure(updatePasswordResult.Error);
        }
        #endregion

        return Result.Success();
    }
}
