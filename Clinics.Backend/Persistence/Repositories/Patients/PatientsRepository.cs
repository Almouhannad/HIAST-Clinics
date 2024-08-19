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


}
