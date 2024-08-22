using Application.Abstractions.CQRS.Commands;
using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Users.Commands.RegisterDoctor;

public class RegisterDoctorHandler : CommandHandlerBase<RegisterDoctorCommand, RegisterDoctorResponse>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;
    public RegisterDoctorHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
    }
    #endregion


    public override async Task<Result<RegisterDoctorResponse>> HandleHelper(RegisterDoctorCommand request, CancellationToken cancellationToken)
    {
        #region 1. Create doctor user
        Result<DoctorUser> doctorUserResult = DoctorUser.Create(
            request.UserName, request.Password,

            request.FirstName, request.MiddleName, request.LastName
            );

        if (doctorUserResult.IsFailure)
            return Result.Failure<RegisterDoctorResponse>(doctorUserResult.Error);
        #endregion

        #region 2. Verify unique username
        var uniqueUserNameResult = await _userRepository.IsUserNameAvailableAsunc(request.UserName);
        if (uniqueUserNameResult.IsFailure)
            return Result.Failure<RegisterDoctorResponse>(uniqueUserNameResult.Error);
        if (uniqueUserNameResult.Value == false)
            return Result.Failure<RegisterDoctorResponse>(IdentityErrors.TakenUserName);
        #endregion

        #region 3. Register (save to DB)
        var registerResult = await _userRepository.RegisterDoctorAsync(doctorUserResult.Value);
        if (registerResult.IsFailure)
            return Result.Failure<RegisterDoctorResponse>(registerResult.Error);
        #endregion

        return RegisterDoctorResponse.GetResponse(registerResult.Value);
    }
}
