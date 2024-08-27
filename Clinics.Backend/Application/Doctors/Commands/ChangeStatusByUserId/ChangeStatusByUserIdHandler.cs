using Application.Abstractions.CQRS.Commands;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Doctors.Commands.ChangeStatusByUserId;

public class ChangeStatusByUserIdHandler : CommandHandlerBase<ChangeStatusByUserIdCommand>
{
    #region CTOR DI
    private readonly IDoctorsRepository _doctorsRepository;
    private readonly IUserRepository _userRepository;
    public ChangeStatusByUserIdHandler(IUnitOfWork unitOfWork, IDoctorsRepository doctorsRepository, IUserRepository userRepository) : base(unitOfWork)
    {
        _doctorsRepository = doctorsRepository;
        _userRepository = userRepository;
    }

    #endregion


    public override async Task<Result> HandleHelper(ChangeStatusByUserIdCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch user and get doctor
        var doctorUserFromPersistenceResult = await _userRepository.GetDoctorUserByIdAsync(request.UserId);
        if (doctorUserFromPersistenceResult.IsFailure)
            return Result.Failure(doctorUserFromPersistenceResult.Error);
        var doctor = doctorUserFromPersistenceResult.Value.Doctor;
        #endregion

        #region 2. Change status
        if (request.Status == doctor.Status.Name)
            return Result.Success();
        var changeStatusResult = doctor.ChangeStatusTo(request.Status);
        if (changeStatusResult.IsFailure)
            return Result.Failure(changeStatusResult.Error);

        #endregion

        #region 3. Persist changes
        var updateResult = await _doctorsRepository.UpdateAsync(doctor);
        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);
        #endregion

        return Result.Success();
    }
}
