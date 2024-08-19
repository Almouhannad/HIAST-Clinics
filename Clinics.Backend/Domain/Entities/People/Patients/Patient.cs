using Domain.Entities.Medicals.Diseases;
using Domain.Entities.Medicals.Medicines;
using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Domain.Entities.People.Shared;
using Domain.Entities.People.Shared.GenderValues;
using Domain.Entities.Visits;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.People.Patients;

// TODO: Potential aggregate?
public sealed class Patient : Entity
{
    #region Private ctor

    private Patient(int id) : base(id) { }

    private Patient(int id, PersonalInfo personalInfo, DateOnly dateOfBirth, Gender gender) : base(id)
    {
        PersonalInfo = personalInfo;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }

    #endregion

    #region Properties

    public PersonalInfo PersonalInfo { get; private set; } = null!;

    public DateOnly DateOfBirth { get; private set; }

    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - DateOfBirth.Year;
            if (today.Month < DateOfBirth.Month || (today.Month == DateOfBirth.Month && today.Day < DateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
    }

    public Gender Gender { get; private set; } = null!;

    #region Navigations

    #region Diseases
    private readonly List<PatientDisease> _diseases = [];
    public IReadOnlyCollection<PatientDisease> Diseases => _diseases;

    #endregion

    #region Medicines
    private readonly List<PatientMedicine> _medicines = [];
    public IReadOnlyCollection<PatientMedicine> Medicines => _medicines;

    #endregion

    #region Visits
    private readonly List<Visit> _visits = [];
    public IReadOnlyCollection<Visit> Visits => _visits;

    #endregion

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<Patient> Create(string firstName, string middleName, string lastName,
        DateOnly dateOfBirth,
        string gender
        )
    {
        #region Personal info
        Result<PersonalInfo> personalInfo = PersonalInfo.Create(firstName, middleName, lastName);
        if (personalInfo.IsFailure)
            return Result.Failure<Patient>(personalInfo.Error);
        #endregion

        #region Gender
        Result<Gender> selectedGender = new(null, false, Errors.DomainErrors.InvalidValuesError);

        Gender male = Genders.Male;
        Gender female = Genders.Female;

        if (gender == male.Name)
            selectedGender = Result.Success<Gender>(male);
        else if (gender == female.Name)
            selectedGender = Result.Success<Gender>(female);

        if (selectedGender.IsFailure)
            return Result.Failure<Patient>(selectedGender.Error);
        #endregion

        return new Patient(0, personalInfo.Value, dateOfBirth, selectedGender.Value);

    }
    #endregion

    #region Add medicine
    public Result AddMedicine(Medicine medicine, int number)
    {
        #region Create medicine to attach
        Result<PatientMedicine> entry = PatientMedicine.Create(Id, medicine.Id, number);
        if (entry.IsFailure)
            return Result.Failure(entry.Error);
        #endregion

        #region Check duplication
        if (Medicines.Where(m => m.MedicineId == medicine.Id).ToList().Count > 0)
            return Result.Failure(Errors.DomainErrors.PatientAlreadyHasThisMedicine);
        #endregion

        _medicines.Add(entry.Value);
        return Result.Success();
    }
    #endregion

    #region Add disease
    public Result AddDisease(Disease disease)
    {
        #region Create disease to attach
        Result<PatientDisease> entry = PatientDisease.Create(Id, disease.Id);
        if (entry.IsFailure)
            return Result.Failure(entry.Error);
        #endregion

        #region Check duplication
        if (Diseases.Where(d => d.DiseaseId == disease.Id).ToList().Count > 0)
            return Result.Failure(Errors.DomainErrors.PatientAlreadyHasThisDisease);
        #endregion

        _diseases.Add(entry.Value);
        return Result.Success();
    }
    #endregion

    #endregion

}
