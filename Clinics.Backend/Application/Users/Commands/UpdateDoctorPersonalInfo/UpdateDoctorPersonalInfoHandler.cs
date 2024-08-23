using Application.Abstractions.CQRS.Commands;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Users.Commands.UpdateDoctorPersonalInfo;

public class UpdateDoctorPersonalInfoHandler : CommandHandlerBase<UpdateDoctorPersonalInfoCommand>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;
    public UpdateDoctorPersonalInfoHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
    }
    #endregion


    public override async Task<Result> HandleHelper(UpdateDoctorPersonalInfoCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch user from database
        var userFromDbResult = await _userRepository.GetDoctorUserByIdAsync(request.Id);
        if (userFromDbResult.IsFailure)
            return Result.Failure(userFromDbResult.Error);
        #endregion

        #region 2. Update personal info
        var updateResult = userFromDbResult.Value.Doctor.PersonalInfo.UpdateDetails(
            request.FirstName, request.MiddleName, request.LastName);
        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);
        #endregion

        #region 3.Save changes
        var saveChangesResult = await _userRepository.UpdateDoctorUserAsync(userFromDbResult.Value);
        if (saveChangesResult.IsFailure)
            return Result.Failure(saveChangesResult.Error);
        #endregion

        return Result.Success();
    }
}
