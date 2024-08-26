using Domain.Entities.Visits;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Visits;

public class VisitsRepository : Repositroy<Visit>, IVisitsRepository
{
    #region CTOR DI For context
    public VisitsRepository(ClinicsDbContext context) : base(context)
    {
    }
    #endregion


    #region Get all by patient id
    public async Task<Result<ICollection<Visit>>> GetAllByPatientIdAsync(int patientId)
    {
        try
        {
            var query = _context.Set<Visit>()
                .Where(visit => visit.PatientId == patientId)
                .OrderByDescending(visit => visit.Date)
                .Include(visit => visit.Doctor)
                    .ThenInclude(doctor => doctor.PersonalInfo)
                .Include(visit => visit.Medicines)
                    .ThenInclude(visitMedicine => visitMedicine.Medicine)
                        .ThenInclude(medicine => medicine.MedicineForm);

            var results = await query.ToListAsync();
            return results;
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Visit>>(PersistenceErrors.Unknown);
        }
    }
    #endregion
}
