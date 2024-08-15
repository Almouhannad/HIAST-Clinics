using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Primitives;

namespace Domain.Entities.WaitingList;

public sealed class WaitingListRecord(int id) : Entity(id)
{
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
}
