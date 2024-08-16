using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Medicals.Diseases;

public sealed class Disease : Entity
{
    #region Private ctor
    private Disease(int id) : base(id) { }

    private Disease(int id, string name) : base(id)
    {
        Name = name;
    }

    #endregion

    #region Properties

    public string Name { get; set; } = null!;

    #region Navigations

    public ICollection<PatientDisease> Patients { get; set; } = [];

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Disease Create(string name)
    {
        if (name is null)
            throw new InvalidValuesDomainException<Disease>();
        return new Disease(0, name);
    }
    #endregion

    #endregion
}
