using Domain.Entities.People.Patients;
using Domain.Primitives;

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

    public Patient Patient { get; set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static FamilyMember Create(string firstName, string middleName, string lastName,
        DateOnly dateOfBirth,
        string gender
        )
    {
        #region Create patient
        Patient patient;

        try
        {
            patient = Patient.Create(firstName, middleName, lastName, dateOfBirth, gender);
        }
        catch
        {
            throw;
        }
        #endregion

        return new FamilyMember(0, patient);
    }
    #endregion

    #endregion
}
