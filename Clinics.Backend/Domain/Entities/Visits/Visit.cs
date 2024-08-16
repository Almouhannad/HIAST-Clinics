using Domain.Entities.Medicals.Hospitals;
using Domain.Entities.Medicals.MedicalImages;
using Domain.Entities.Medicals.MedicalTests;
using Domain.Entities.Medicals.Medicines;
using Domain.Entities.People.Doctors;
using Domain.Entities.People.Patients;
using Domain.Entities.Visits.Relations.VisitMedicalImages;
using Domain.Entities.Visits.Relations.VisitMedicalTests;
using Domain.Entities.Visits.Relations.VisitMedicines;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    #endregion

    #region Doctor

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    #endregion

    #region Additional

    public DateOnly Date { get; set; }

    public string Diagnosis { get; set; } = null!;

    #region Hospital

    public int? HospitalId { get; set; }
    public Hospital? Hospital { get; set; }

    #endregion

    #endregion

    #region Navigations

    public ICollection<VisitMedicalImage> MedicalImages { get; set; } = [];
    public ICollection<VisitMedicalTest> MedicalTests { get; set; } = [];
    public ICollection<VisitMedicine> Medicines { get; set; } = [];

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Visit Create(int patientId, int doctorId,  DateOnly date, string diagnosis)
    {
        if (patientId <= 0 || doctorId <= 0 || diagnosis is null)
            throw new InvalidValuesDomainException<Visit>();
        
        return new Visit(0, patientId, doctorId, date, diagnosis);
    }
    #endregion

    #region Add medical image
    public void AddMedicalImage(MedicalImage medicalImage)
    {
        VisitMedicalImage entry;
        try
        {
            entry = VisitMedicalImage.Create(Id, medicalImage.Id);
        }
        catch
        {
            throw;
        }

        if (MedicalImages is null)
            MedicalImages = [];

        MedicalImages.Add(entry);
    }
    #endregion

    #region Add medical test
    public void AddMedicalTest(MedicalTest medicalTest)
    {
        VisitMedicalTest entry;
        try
        {
            entry = VisitMedicalTest.Create(Id, medicalTest.Id);
        }
        catch
        {
            throw;
        }
        if (MedicalTests is null)
            MedicalTests = [];
        MedicalTests.Add(entry);
    }
    #endregion

    #region Add medicine
    public void AddMedicine (Medicine medicine, int number)
    {
        VisitMedicine entry;
        try
        {
            entry = VisitMedicine.Create(Id, medicine.Id, number);
        }
        catch
        {
            throw;
        }
        if (Medicines is null)
            Medicines = [];
        Medicines.Add(entry);
    }
    #endregion

    #region Add hospital
    public void AddHospital(Hospital hospital)
    {
        if (hospital is null)
            throw new InvalidValuesDomainException<Visit>();
        Hospital = hospital;
        HospitalId = hospital.Id;
    }
    #endregion

    #endregion
}
