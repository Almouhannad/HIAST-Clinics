using Domain.Entities.Medicals.Hospitals;
using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Entities.Visits.Relations.VisitMedicalImages;
using Domain.Entities.Visits.Relations.VisitMedicalTests;
using Domain.Entities.Visits.Relations.VisitMedicines;
using Domain.Primitives;

namespace Domain.Entities.Visits;

public sealed class Visit(int id) : Entity(id)
{
    #region Properties

    public Patient Patient { get; set; } = null!;

    public Doctor Doctor { get; set; } = null!;

    public Hospital? Hospital { get; set; }

    public DateOnly Date { get; set; }

    public string Diagnosis { get; set; } = null!;

    #region Navigations

    public ICollection<VisitMedicalImage> MedicalImages { get; set; } = [];
    public ICollection<VisitMedicalTest> MedicalTests { get; set; } = [];
    public ICollection<VisitMedicine> Medicines { get; set; } = [];

    #endregion

    #endregion
}
