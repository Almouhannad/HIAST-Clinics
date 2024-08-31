using Application.Abstractions.CQRS.Commands;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Doctors.Commands.AddPhoneNumberByUserId;

public class AddPhoneNumberByUserIdHandler : CommandHandlerBase<AddPhoneNumberByUserIdCommand>
{

    #region CTOR DI
    private readonly IUserRepository _userRepository;
    private readonly IDoctorsRepository _doctorsRepository;
    public AddPhoneNumberByUserIdHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IDoctorsRepository doctorsRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
        _doctorsRepository = doctorsRepository;
    }
    #endregion


    public override async Task<Result> HandleHelper(AddPhoneNumberByUserIdCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch Doctor from persistence
        var doctorFromPersistenceResult = await _userRepository
            .GetDoctorByDoctorUserIdAsync(request.DoctorUserId);
        if (doctorFromPersistenceResult.IsFailure)
            return Result.Failure(doctorFromPersistenceResult.Error);
        var doctor = doctorFromPersistenceResult.Value;
        #endregion

        #region 2. Add phone number
        var addPhoneNumberResult = doctor.AddPhone(request.Phone, request.Name);
        if (addPhoneNumberResult.IsFailure)
            return Result.Failure(addPhoneNumberResult.Error);
        #endregion

        #region 3. save updates
        var saveUpdatesResult = await _doctorsRepository.UpdateAsync(doctor);
        if (saveUpdatesResult.IsFailure)
            return Result.Failure(saveUpdatesResult.Error);
        #endregion

        return Result.Success();
    }
}
