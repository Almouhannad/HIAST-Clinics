using Application.Abstractions.CQRS.Commands;
using Domain.Entities.Visits;
using Domain.Repositories;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Visits.Commands.Create;

public class CreateVisitCommandHandler : CommandHandlerBase<CreateVisitCommand>
{
    #region CTOR DI
    private readonly IUserRepository _userRepository;
    private readonly IVisitsRepository _visitsRepository;
    public CreateVisitCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IVisitsRepository visitsRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
        _visitsRepository = visitsRepository;
    }
    #endregion


    public override async Task<Result> HandleHelper(CreateVisitCommand request, CancellationToken cancellationToken)
    {
        #region 1. Fetch doctor from persistence
        var doctorFromPersistenceResult = await _userRepository.GetDoctorByDoctorUserIdAsync(request.DoctorUserId);
        if (doctorFromPersistenceResult.IsFailure)
            return Result.Failure(doctorFromPersistenceResult.Error);
        var doctorId = doctorFromPersistenceResult.Value.Id;
        #endregion

        #region 2. Create visit
        var createVisitResult = Visit.Create(request.PatientId, doctorId,
            DateOnly.FromDateTime(DateTime.Today),request.Diagnosis);
        if (createVisitResult.IsFailure)
            return Result.Failure(createVisitResult.Error);
        var saveVisitToPersistenceResult = await _visitsRepository.CreateAsync(createVisitResult.Value);
        if (saveVisitToPersistenceResult.IsFailure)
            return Result.Failure(saveVisitToPersistenceResult.Error);
        var visit = saveVisitToPersistenceResult.Value;
        #endregion

        #region 3. Add medicines to visit
        foreach (var medicine in request.Medicines)
        {
            var addResult = visit.AddMedicine(medicine.MedicineId, medicine.Number);
            if (addResult.IsFailure)
                return Result.Failure(addResult.Error);
        }
        #endregion

        #region 4. Save visit to persistence
        var saveResult = await _visitsRepository.UpdateAsync(visit);
        if (saveResult.IsFailure)
            return Result.Failure(saveResult.Error);
        #endregion

        return Result.Success();
    }
}
