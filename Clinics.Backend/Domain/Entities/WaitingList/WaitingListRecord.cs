using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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

    public static WaitingListRecord Create(int patientId)
    {
        if (patientId <= 0)
            throw new InvalidValuesDomainException<WaitingListRecord>();
        return new WaitingListRecord(0, patientId);
    }

    #endregion

    #region Link to doctor
    public void LinkToDoctor(int doctorId)
    {
        if (doctorId <= 0)
            throw new InvalidValuesDomainException<WaitingListRecord>();
        DoctorId = doctorId;
    }
    #endregion

    #endregion
}
