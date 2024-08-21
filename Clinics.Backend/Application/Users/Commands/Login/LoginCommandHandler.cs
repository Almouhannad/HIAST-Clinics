using Application.Abstractions.CQRS.Commands;
using Application.Abstractions.JWT;
using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Users.Commands.Login;

public class LoginCommandHandler : CommandHandlerBase<LoginCommand, string>
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

    public override async Task<Result<string>> HandleHelper(LoginCommand request, CancellationToken cancellationToken)
    {
        #region 1. Check username and password are correct
        Result<User?> loginResult = await _userRepository.VerifyPasswordAsync(request.UserName, request.Password);

        if (loginResult.IsFailure)
            return Result.Failure<string>(loginResult.Error); // Not found username

        if (loginResult.Value is null) // Invalid password
            return Result.Failure<string>(IdentityErrors.PasswordMismatch);
        #endregion

        #region 2. Generate JWT
        User user = loginResult.Value!;
        string token = _jwtProvider.Generate(user);
        #endregion

        return Result.Success<string>(token);
    }


}
