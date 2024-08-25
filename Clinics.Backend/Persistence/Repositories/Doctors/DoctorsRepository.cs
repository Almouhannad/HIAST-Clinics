using Domain.Entities.People.Doctors;
using Domain.Entities.People.Doctors.Shared.DoctorStatusValues;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Doctors.Specifications;
using System.Collections.Generic;

namespace Persistence.Repositories.Doctors;

public class DoctorsRepository : Repositroy<Doctor>, IDoctorsRepository
{
    #region CTOR DI
    public DoctorsRepository(ClinicsDbContext context) : base(context)
    {
    }
    #endregion

    #region Read methods
    public override async Task<Result<ICollection<Doctor>>> GetAllAsync()
    {
        try
        {
            var query = ApplySpecification(new FullDoctorSpecification(doctor => true));
            return await query.ToListAsync();
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Doctor>>(PersistenceErrors.Unknown);
        }
    }
    #endregion

    #region Get available
    public async Task<Result<ICollection<Doctor>>> GetAvailableDoctors()
    {
        try
        {
            var query = _context.Set<Doctor>()
                .Include(doctor => doctor.Status)
                .Where(doctor => doctor.Status == DoctorStatuses.Available)
                .Include(doctor => doctor.PersonalInfo);
            var result = await query.ToListAsync();
            return result;
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Doctor>>(PersistenceErrors.Unknown);
        }
    }
    #endregion
}
