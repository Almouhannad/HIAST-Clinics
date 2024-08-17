using Domain.Entities.Medicals.Diseases;
using Domain.Entities.Medicals.Medicines;
using Domain.Entities.People.Patients.Relations.PatientDiseases;
using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Domain.Entities.People.Shared;
using Domain.Entities.People.Shared.GenderValues;
using Domain.Entities.Visits;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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
    public static Patient Create(string firstName, string middleName, string lastName,
        DateOnly dateOfBirth,
        string gender
        )
    {
        #region Personal info
        PersonalInfo? personalInfo;

        try
        {
            personalInfo = PersonalInfo.Create(firstName, middleName, lastName);
        }
        catch
        {
            throw;
        }
        #endregion

        #region Gender
        if (gender is null)
            throw new InvalidValuesDomainException<Gender>();

        Gender? selectedGender;

        Gender male = Genders.Male;
        Gender female = Genders.Female;

        if (gender == male.Name)
            selectedGender = male;
        else if (gender == female.Name)
            selectedGender = female;
        else selectedGender = null;

        if (selectedGender is null)
            throw new InvalidValuesDomainException<Gender>();
        #endregion

        return new Patient(0, personalInfo, dateOfBirth, selectedGender);

    }
    #endregion

    #region Add medicine
    public void AddMedicine(Medicine medicine, int number)
    {
        PatientMedicine entry;

        try
        {
            entry = PatientMedicine.Create(Id, medicine.Id, number);
        }
        catch
        {
            throw;
        }

        _medicines.Add(entry);
    }
    #endregion

    #region Add disease
    public void AddDisease (Disease disease)
    {
        PatientDisease entry;
        try
        {
            entry = PatientDisease.Create(Id, disease.Id);
        }
        catch
        {
            throw;
        }

        _diseases.Add(entry);
    }
    #endregion

    #endregion

}
