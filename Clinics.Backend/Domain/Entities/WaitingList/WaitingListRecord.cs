using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.WaitingList;

public sealed class WaitingListRecord : Entity
{
    #region Private ctor
    private WaitingListRecord(int id) : base(id) { }

    private WaitingListRecord(int id, int patientId, DateTime arrivalTime) : base(id)
    {
        PatientId = patientId;
        ArrivalTime = arrivalTime;
    }

    #endregion

    #region Properties

    #region Patient

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    #endregion

    #region Additional

    public DateTime ArrivalTime { get; set; }

    #endregion

    #endregion

    #region Methods

    #region Static factory

    public static Result<WaitingListRecord> Create(int patientId)
    {
        if (patientId <= 0)
            return Result.Failure<WaitingListRecord>(Errors.DomainErrors.InvalidValuesError);
        return new WaitingListRecord(0, patientId, DateTime.Now);
    }

    #endregion

    #endregion
}
