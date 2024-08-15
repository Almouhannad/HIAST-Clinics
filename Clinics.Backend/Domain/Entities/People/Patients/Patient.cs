using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Entities.People.Shared;
using Domain.Entities.People.Shared.Constants.GenderValues;
using Domain.Primitives;

namespace Domain.Entities.People.Patients;

// TODO: Potential aggregate?
public sealed class Patient(int id) : Entity(id)
{
    #region Properties

    public PersonalInfo PersonalInfo { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public Gender Gender { get; set; } = null!;

    #region Navigations

    public ICollection<PatientDisease> Diseases { get; set; } = [];

    public ICollection<PatientMedicine> Medicines { get; set; } = [];

    public ICollection<Visit> Visits { get; set; } = [];

    #endregion

    #endregion

}
