using Domain.Entities.People.Patients;
using Domain.Primitives;

namespace Domain.Entities.People.FamilyMembers;

public sealed class FamilyMember(int id) : Entity(id)
{
    #region Properties

    public Patient Patient { get; set; } = null!;

    #endregion
}
