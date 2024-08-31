using Domain.Entities.Identity.Users;
using Domain.Entities.People.Doctors;
using Domain.Entities.People.Doctors.Shared.DoctorStatusValues;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;
using Persistence.Repositories.Doctors.Specifications;

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

    #region Update method
    public override Task<Result> UpdateAsync(Doctor entity)
    {
        if (entity.Status is not null)
            _context.Entry(entity.Status).State = EntityState.Unchanged;
        return base.UpdateAsync(entity);
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

    #region Get user
    public async Task<Result<DoctorUser>> GetUserByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<DoctorUser>()
                .Include(doctorUser => doctorUser.Doctor)
                .Where(doctorUser => doctorUser.Doctor.Id == id)
                .Include(doctorUser => doctorUser.User);
            var result = await query.FirstAsync();
            return result;

        }
        catch (Exception)
        {
            return Result.Failure<DoctorUser>(PersistenceErrors.NotFound);
        }
    }
    #endregion
}
