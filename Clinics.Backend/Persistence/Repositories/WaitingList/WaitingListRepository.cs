using Domain.Entities.People.Employees;
using Domain.Entities.WaitingList;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.WaitingList;

public class WaitingListRepository : Repositroy<WaitingListRecord>, IWaitingListRepository
{
    #region CTOR DI
    public WaitingListRepository(ClinicsDbContext context) : base(context)
    {
    }
    #endregion


    #region Read methods
    public override async Task<Result<WaitingListRecord>> GetByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<WaitingListRecord>()
                .Where(waitingListRecord => waitingListRecord.Id == id)
                .OrderByDescending(witingListRecord => witingListRecord.ArrivalTime)
                .Include(witingListRecord => witingListRecord.Patient)
                    .ThenInclude(patient => patient.PersonalInfo)
                .Include(witingListRecord => witingListRecord.Patient)
                    .ThenInclude(patient => patient.Gender);
            return await query.FirstAsync();
        }
        catch (Exception)
        {
            return Result.Failure<WaitingListRecord>(PersistenceErrors.NotFound);
        }
    }

    public override async Task<Result<ICollection<WaitingListRecord>>> GetAllAsync()
    {
        try
        {
            var query = _context.Set<WaitingListRecord>()
                .OrderBy(waitingListRecord => waitingListRecord.ArrivalTime)
                .Include(waitingListRecord => waitingListRecord.Patient)
                    .ThenInclude(patient => patient.PersonalInfo)
                .Include(waitingListRecord => waitingListRecord.Patient)
                    .ThenInclude(patient => patient.Gender);
            return await query.ToListAsync();
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<WaitingListRecord>>(PersistenceErrors.Unknown);
        }
    }
    #endregion

    #region Is employee in list
    public async Task<Result<bool>> IsEmployeeInWaitingListAsync(string serialNumber)
    {
        try
        {
            var employee = await _context.Set<Employee>()
                .Where(employee => employee.SerialNumber == serialNumber)
                .FirstAsync();
            var query = _context.Set<WaitingListRecord>()
                .Where(waitingListRecord => waitingListRecord.PatientId == employee.Id);
            var result = await query.ToListAsync();
            return result.Count == 1;
        }
        catch (Exception)
        {
            return Result.Failure<bool>(PersistenceErrors.NotFound);
        }
    }

    #endregion
}
