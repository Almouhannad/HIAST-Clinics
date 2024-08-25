using Domain.Entities.People.Employees;
using Domain.Entities.People.FamilyMembers;
using Domain.Entities.People.Patients;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Patients.Specifications;

namespace Persistence.Repositories.Patients;

public class PatientsRepository : Repositroy<Patient>, IPatientsRepository
{
    #region CTOR DI for context
    public PatientsRepository(ClinicsDbContext context) : base(context)
    {
    }
    #endregion

    #region Read operations FULL
    public async Task<Result<ICollection<Patient>>> GetAllFullAsync(int id)
    {
        var query = ApplySpecification(new FullSpecification(patient => true)); // Get all
        try
        {
            var patients = await query.ToListAsync();
            return Result.Success<ICollection<Patient>>(patients);
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Patient>>(PersistenceErrors.NotFound);
        }
    }

    public async Task<Result<Patient>> GetByIdFullAsync(int id)
    {
        var query = ApplySpecification(new FullSpecification(patient => patient.Id == id)); // Get all
        try
        {
            var patient = await query.FirstAsync();
            return Result.Success<Patient>(patient);
        }
        catch (Exception)
        {
            return Result.Failure<Patient>(PersistenceErrors.NotFound);
        }
    }
    #endregion

    #region Create operation
    public override Task<Result<Patient>> CreateAsync(Patient entity)
    {
        _context.Entry(entity.Gender).State = EntityState.Unchanged;
        return base.CreateAsync(entity);
    }
    #endregion

    #region IsEmployee
    public async Task<Result<bool>> IsEmployeeByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<Employee>()
                .Where(employee => employee.Id == id);
            var result = await query.ToListAsync();
            return result.Count == 1;
        }
        catch (Exception)
        {
            return Result.Failure<bool>(PersistenceErrors.NotFound);
        }
    }
    public async Task<Result<Employee>> GetEmployeeByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<Employee>()
                .Where(employee => employee.Id == id) // Note that this is only one row
                .Include(employee => employee.Patient) // so, join is effecient
                    .ThenInclude(patient => patient.PersonalInfo)
                .Include(employee => employee.Patient)
                    .ThenInclude(patient => patient.Gender)
                .Include(employee => employee.Patient)
                    .ThenInclude(patient => patient.Diseases)
                .Include(employee => employee.Patient)
                    .ThenInclude(patient => patient.Medicines)
                .Include(employee => employee.Patient)
                    .ThenInclude(patient => patient.Visits)
                .Include(employee => employee.AdditionalInfo)
                .Include(employee => employee.FamilyMembers)
                .Include(employee => employee.RelatedEmployees)
                .Include(employee => employee.RelatedTo);
            return await query.FirstAsync();
        }
        catch (Exception)
        {
            return Result.Failure<Employee>(PersistenceErrors.NotFound);
        }

    }
    #endregion

    #region FamilyMember
    public async Task<Result<bool>> IsFamilyMemberByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<FamilyMember>()
                .Where(familyMember => familyMember.Id == id);
            var result = await query.ToListAsync();
            return result.Count == 1;
        }
        catch (Exception)
        {
            return Result.Failure<bool>(PersistenceErrors.NotFound);
        }
    }
    public async Task<Result<FamilyMember>> GetFamilyMemberByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<FamilyMember>()
                .Where(familyMember => familyMember.Id == id) // Note that this is only one row
                .Include(familyMember => familyMember.Patient) // so, join is effecient
                    .ThenInclude(patient => patient.PersonalInfo)

                .Include(familyMember => familyMember.Patient)
                    .ThenInclude(patient => patient.Gender)

                .Include(familyMember => familyMember.Patient)
                    .ThenInclude(patient => patient.Diseases)

                .Include(familyMember => familyMember.Patient)
                    .ThenInclude(patient => patient.Medicines)

                .Include(familyMember => familyMember.Patient)
                    .ThenInclude(patient => patient.Visits);

            return await query.FirstAsync();
        }
        catch (Exception)
        {
            return Result.Failure<FamilyMember>(PersistenceErrors.NotFound);
        }
    }
    #endregion
}
