using Domain.Entities.People.Patients;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.People.FamilyMembers;

public sealed class FamilyMember : Entity
{
    #region Private ctor
    private FamilyMember(int id) : base(id)
    {
    }

    private FamilyMember(int id, Patient patient) : base(id)
    {
        Patient = patient;
    }
    #endregion

    #region Properties

    public Patient Patient { get; private set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static Result<FamilyMember> Create(string firstName, string middleName, string lastName,
        DateOnly dateOfBirth,
        string gender
        )
    {
        #region Create patient
        Result<Patient> patient = Patient.Create(firstName, middleName, lastName, dateOfBirth, gender);
        if (patient.IsFailure)
            return Result.Failure<FamilyMember>(patient.Error);
        #endregion

        return new FamilyMember(0, patient.Value);
    }
    #endregion

    #endregion
}
