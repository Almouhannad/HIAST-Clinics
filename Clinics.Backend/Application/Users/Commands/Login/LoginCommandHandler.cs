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

        User user = loginResult.Value!;

        #region 2. Generate Response

        #region 2.1. Admin
        if (user.Role == UsersRoles.Admin)
        {
            var token = _jwtProvider.Generate(user);
            return LoginResponse.GetResponse(token);
        }
        #endregion

        #region 2.2. Doctor
        if (user.Role == UsersRoles.Doctor)
        {
            var doctorUserResult = await _userRepository.GetDoctorUserByUserNameFullAsync(user.UserName);
            if (doctorUserResult.IsFailure)
                return Result.Failure<LoginResponse>(doctorUserResult.Error);

            var token = _jwtProvider.Generate(user, doctorUserResult.Value.Doctor.PersonalInfo);
            return LoginResponse.GetResponse(token);
        }
        #endregion

        #region 2.3. Receptionist user
        if (user.Role == UsersRoles.Receptionist)
        {
            var receptionistUser = await _userRepository.GetReceptionistUserByUserNameFullAsync(user.UserName);
            if (receptionistUser.IsFailure)
                return Result.Failure<LoginResponse>(receptionistUser.Error);
            var token = _jwtProvider.Generate(user, receptionistUser.Value.PersonalInfo);
            return LoginResponse.GetResponse(token);
        }

        #endregion

        return Result.Failure<LoginResponse>(IdentityErrors.NotFound);

        #endregion

    }


}
