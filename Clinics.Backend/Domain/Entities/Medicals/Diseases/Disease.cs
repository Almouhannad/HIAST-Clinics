using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Primitives;

namespace Domain.Entities.Medicals.Diseases;

public sealed class Disease(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    #region Navigations

    public ICollection<PatientDisease> Patients { get; set; } = [];

    #endregion

    #endregion
}
