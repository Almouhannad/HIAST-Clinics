using Application.Abstractions.CQRS.Commands;
using Application.Users.Commands.RegisterDoctor;
using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Users.Commands.RegisterReceptionist;

public class RegisterReceptionistCommandHandler : CommandHandlerBase<RegisterReceptionistCommand, RegisterReceptionistResponse>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;
    public RegisterReceptionistCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
    }
    #endregion


    public override async Task<Result<RegisterReceptionistResponse>> HandleHelper(RegisterReceptionistCommand request, CancellationToken cancellationToken)
    {
        #region 1. Create receptionist user
        Result<ReceptionistUser> receptionistUserResult = ReceptionistUser.Create(
            request.UserName, request.Password,

            request.FirstName, request.MiddleName, request.LastName
            );

        if (receptionistUserResult.IsFailure)
            return Result.Failure<RegisterReceptionistResponse>(receptionistUserResult.Error);
        #endregion

        #region 2. Verify unique username
        var uniqueUserNameResult = await _userRepository.IsUserNameAvailableAsunc(request.UserName);
        if (uniqueUserNameResult.IsFailure)
            return Result.Failure<RegisterReceptionistResponse>(uniqueUserNameResult.Error);
        if (uniqueUserNameResult.Value == false)
            return Result.Failure<RegisterReceptionistResponse>(IdentityErrors.TakenUserName);
        #endregion

        #region 3. Register (save to DB)
        var registerResult = await _userRepository.RegisterReceptionistAsync(receptionistUserResult.Value);
        if (registerResult.IsFailure)
            return Result.Failure<RegisterReceptionistResponse>(registerResult.Error);
        #endregion

        return RegisterReceptionistResponse.GetResponse(registerResult.Value);


        throw new NotImplementedException();
    }
}
