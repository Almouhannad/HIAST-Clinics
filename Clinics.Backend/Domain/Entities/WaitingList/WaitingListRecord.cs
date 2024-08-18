using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.WaitingList;

public sealed class WaitingListRecord : Entity
{
    #region Private ctor
    private WaitingListRecord(int id) : base(id) { }

    private WaitingListRecord(int id, int patientId) : base(id)
    {
        PatientId = patientId;
        IsServed = false;
    }

    #endregion

    #region Properties

    #region Patient

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    #endregion

    #region Doctor

    public int? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    #endregion

    #region Additional

    public bool IsServed { get; set; } = false;

    #endregion

    #endregion

    #region Methods

    #region Static factory

    public static Result<WaitingListRecord> Create(int patientId)
    {
        if (patientId <= 0)
            return Result.Failure<WaitingListRecord>(Errors.DomainErrors.InvalidValuesError);
        return new WaitingListRecord(0, patientId);
    }

    #endregion

    #region Link to doctor
    public Result LinkToDoctor(int doctorId)
    {
        if (doctorId <= 0)
            return Result.Failure(Errors.DomainErrors.InvalidValuesError);

        DoctorId = doctorId;
        return Result.Success();
    }
    #endregion

    #endregion
}
