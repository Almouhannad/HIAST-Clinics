using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Primitives;
using Domain.Shared;

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

    #region Patients
    private readonly List<PatientDisease> _patients = [];
    public IReadOnlyCollection<PatientDisease> Patients => _patients;

    #endregion

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<Disease> Create(string name)
    {
        if (name is null)
            return Result.Failure<Disease>(Errors.DomainErrors.InvalidValuesError);
        return new Disease(0, name);
    }
    #endregion

    #endregion
}
