using Domain.Entities.Medicals.Hospitals;
using Domain.Entities.Medicals.MedicalImages;
using Domain.Entities.Medicals.MedicalTests;
using Domain.Entities.Medicals.Medicines;
using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Entities.Visits.Relations.VisitMedicalImages;
using Domain.Entities.Visits.Relations.VisitMedicalTests;
using Domain.Entities.Visits.Relations.VisitMedicines;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Visits;

public sealed class Visit : Entity
{
    #region Private ctor

    private Visit(int id) : base(id) { }

    private Visit(int id, int patientId, int doctorId, DateOnly date, string diagnosis) : base(id)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        Date = date;
        Diagnosis = diagnosis;

        HospitalId = null;
    }

    #endregion

    #region Properties

    #region Patient

    public int PatientId { get; private set; }
    public Patient Patient { get; private set; } = null!;

    #endregion

    #region Doctor

    public int DoctorId { get; private set; }
    public Doctor Doctor { get; private set; } = null!;

    #endregion

    #region Additional

    public DateOnly Date { get; private set; }

    public string Diagnosis { get; private set; } = null!;

    #region Hospital

    public int? HospitalId { get; set; }
    public Hospital? Hospital { get; set; }

    #endregion

    #endregion

    #region Navigations

    #region Medical images
    private readonly List<VisitMedicalImage> _medicalImages = [];
    public IReadOnlyCollection<VisitMedicalImage> MedicalImages => _medicalImages;

    #endregion

    #region Medical tests
    private readonly List<VisitMedicalTest> _medicalTests = [];
    public IReadOnlyCollection<VisitMedicalTest> MedicalTests => _medicalTests;

    #endregion

    #region Medicines
    private readonly List<VisitMedicine> _medicines = [];
    public IReadOnlyCollection<VisitMedicine> Medicines => _medicines;

    #endregion

    #endregion

    #region Holiday
    public Holiday? Holiday { get; private set; }
    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<Visit> Create(int patientId, int doctorId, DateOnly date, string diagnosis)
    {
        if (patientId <= 0 || doctorId <= 0 || diagnosis is null)
            return Result.Failure<Visit>(Errors.DomainErrors.InvalidValuesError);

        return new Visit(0, patientId, doctorId, date, diagnosis);
    }
    #endregion

    #region Add medical image
    public Result AddMedicalImage(MedicalImage medicalImage)
    {
        #region Create medical image to attach
        Result<VisitMedicalImage> entry = VisitMedicalImage.Create(Id, medicalImage.Id);
        if (entry.IsFailure)
            return Result.Failure(entry.Error);
        #endregion

        #region Check duplicate
        if (MedicalImages.Where(mi => mi.MedicalImage == medicalImage).ToList().Count > 0)
            return Result.Failure(Errors.DomainErrors.VisitAlreadyHasThisMedicalImage);
        #endregion

        _medicalImages.Add(entry.Value);
        return Result.Success();
    }
    #endregion

    #region Add medical test
    public Result AddMedicalTest(MedicalTest medicalTest)
    {
        #region Create medical test to attach
        Result<VisitMedicalTest> entry = VisitMedicalTest.Create(Id, medicalTest.Id);
        if (entry.IsFailure)
            return Result.Failure(entry.Error);
        #endregion

        #region Check duplicate
        if (MedicalTests.Where(mt => mt.MedicalTest == medicalTest).ToList().Count > 0)
            return Result.Failure(Errors.DomainErrors.VisitAlreadyHasThisMedicalTest);
        #endregion

        _medicalTests.Add(entry.Value);
        return Result.Success();
    }
    #endregion

    #region Add medicine
    public Result AddMedicine(int medicineId, int number)
    {
        #region Create medicine to attach
        Result<VisitMedicine> entry = VisitMedicine.Create(Id, medicineId, number);
        if (entry.IsFailure)
            return Result.Failure(entry.Error);
        #endregion

        //#region Check duplicate
        //if (Medicines.Where(m => m.Medicine.Id == medicineId).ToList().Count > 0)
        //    return Result.Failure(Errors.DomainErrors.VisitAlreadyHasThisMedicine);
        //#endregion

        _medicines.Add(entry.Value);
        return Result.Success();
    }
    #endregion

    #region Add hospital
    public Result AddHospital(Hospital hospital)
    {
        if (hospital is null)
            return Result.Failure(Errors.DomainErrors.InvalidValuesError);

        Hospital = hospital;
        HospitalId = hospital.Id;
        return Result.Success();
    }
    #endregion

    #region Add holiday
    public Result AddHoliday(DateOnly from, int duration)
    {
        var holidayResult = Holiday.Create(Id, from, duration);
        if (holidayResult.IsFailure)
            return Result.Failure(holidayResult.Error);
        Holiday = holidayResult.Value;
        return Result.Success();

    }
    #endregion

    #endregion
}
