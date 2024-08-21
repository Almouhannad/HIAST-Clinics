using Application.Abstractions.CQRS.Commands;
using Application.Abstractions.JWT;
using Domain.Entities.Identity.UserRoles;
using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Users.Commands.Login;

public class LoginCommandHandler : CommandHandlerBase<LoginCommand, LoginResponse>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;
    private readonly IJWTProvider _jwtProvider;
    public LoginCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IJWTProvider jwtProvider) : base(unitOfWork)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }
    #endregion

    public override async Task<Result<LoginResponse>> HandleHelper(LoginCommand request, CancellationToken cancellationToken)
    {
        #region 1. Check username and password are correct
        Result<User?> loginResult = await _userRepository.VerifyPasswordAsync(request.UserName, request.Password);

        if (loginResult.IsFailure)
            return Result.Failure<LoginResponse>(loginResult.Error); // Not found username

        if (loginResult.Value is null) // Invalid password
            return Result.Failure<LoginResponse>(IdentityErrors.PasswordMismatch);
        #endregion

        #region 2. Generate JWT
        User user = loginResult.Value!;
        string token = _jwtProvider.Generate(user);
        #endregion

        #region 3. Generate Response

        #region 3.1. Admin
        if (user.Role == Roles.Admin)
        {
            return LoginResponse.GetResponse(user, token);
        }
        #endregion

        #region 3.2. Doctor
        if (user.Role == Roles.Doctor)
        {
            var doctorUserResult = await _userRepository.GetDoctorUserByUserNameFullAsync(user.UserName);
            if (doctorUserResult.IsFailure)
                return Result.Failure<LoginResponse>(doctorUserResult.Error);
            return LoginResponse.GetResponse(doctorUserResult.Value.User, token, doctorUserResult.Value.Doctor.PersonalInfo);
        }
        #endregion

        #region 3.3. Receptionist user
        if (user.Role == Roles.Receptionist)
        {
            var receptionistUser = await _userRepository.GetReceptionistUserByUserNameFullAsync(user.UserName);
            if (receptionistUser.IsFailure)
                return Result.Failure<LoginResponse>(receptionistUser.Error);
            return LoginResponse.GetResponse(receptionistUser.Value.User, token, receptionistUser.Value.PersonalInfo);
        }

        #endregion

        return Result.Failure<LoginResponse>(IdentityErrors.NotFound);

        #endregion

    }


}
