using Application.Abstractions.CQRS.Commands;
using Application.Abstractions.Notifications.Doctors;
using Application.Abstractions.Notifications.Doctors.NewVisitNotifications;
using Domain.Entities.People.Doctors.Shared.DoctorStatusValues;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.WaitingList.Commands.SendWaitingListRecordToDoctor;

public class SendWaitingListRecordToDoctorHandler : CommandHandlerBase<SendWaitingListRecordToDoctorCommand>
{
    #region CTOR DI
    private readonly IPatientsRepository _patientsRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDoctorsRepository _doctorsRepository;
    private readonly IWaitingListRepository _waitingListRepository;
    private readonly IDoctorsNotificationService _doctorsNotificationService;
    public SendWaitingListRecordToDoctorHandler(IUnitOfWork unitOfWork, IPatientsRepository patientsRepository, IUserRepository userRepository, IDoctorsRepository doctorsRepository, IWaitingListRepository waitingListRepository, IDoctorsNotificationService doctorsNotificationService) : base(unitOfWork)
    {
        _patientsRepository = patientsRepository;
        _userRepository = userRepository;
        _doctorsRepository = doctorsRepository;
        _waitingListRepository = waitingListRepository;
        _doctorsNotificationService = doctorsNotificationService;
    }
    #endregion


    public override async Task<Result> HandleHelper(SendWaitingListRecordToDoctorCommand request, CancellationToken cancellationToken)
    {
        #region 1. Delete record
        var recordFromPersistence = await _waitingListRepository.GetByIdAsync(request.WaitingListRecordId);
        if (recordFromPersistence.IsFailure)
            return Result.Failure(recordFromPersistence.Error);
        var record = recordFromPersistence.Value;
        await _waitingListRepository.DeleteAsync(record);
        #endregion

        #region 2. Set doctor status to working
        var doctorFromPersistence = await _doctorsRepository.GetByIdAsync(request.DoctorId);
        if (doctorFromPersistence.IsFailure)
            return Result.Failure(doctorFromPersistence.Error);
        var doctor = doctorFromPersistence.Value;
        doctor.ChangeStatusTo(DoctorStatuses.Working);
        var changeStatusResult = await _doctorsRepository.UpdateAsync(doctor);
        if (changeStatusResult.IsFailure)
            return Result.Failure(changeStatusResult.Error);
        #endregion

        #region 3. Get doctor user
        var doctorUserFromPersistence = await _doctorsRepository.GetUserByIdAsync(request.DoctorId);
        if (doctorUserFromPersistence.IsFailure)
            return Result.Failure(doctorUserFromPersistence.Error);
        var doctorUser = doctorUserFromPersistence.Value;
        #endregion

        #region 4. Get patient
        var patientFromPersistence = await _patientsRepository.GetByIdFullAsync(request.PatientId);
        if (patientFromPersistence.IsFailure)
            return Result.Failure(patientFromPersistence.Error);
        var patient = patientFromPersistence.Value;
        #endregion

        #region 5. Send notification
        var notification = NewVisitNotification.Create(request.PatientId, patient.PersonalInfo.FirstName, request.DoctorId, doctorUser.Id);
        await _doctorsNotificationService.SendNewVisitNotification(notification);
        #endregion

        return Result.Success();
    }
}
