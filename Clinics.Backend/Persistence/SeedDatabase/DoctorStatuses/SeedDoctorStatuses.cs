using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.SeedDatabase.DoctorStatuses;

public class SeedDoctorStatuses : ISeed<DoctorStatus>
{
    #region Ctor DI
    private readonly ClinicsDbContext _clinicsContext;

    public SeedDoctorStatuses(ClinicsDbContext clinicsContext)
    {
        _clinicsContext = clinicsContext;
    }
    #endregion
    public async Task Seed()
    {
        DbSet<DoctorStatus> doctorStatuses = _clinicsContext.Set<DoctorStatus>();

        if (doctorStatuses.ToList().Count !=
            Domain.Entities.People.Doctors.Shared.DoctorStatusValues.DoctorStatuses.Count)
        {
            doctorStatuses.RemoveRange(doctorStatuses.ToList());

            doctorStatuses.Add
                (Domain.Entities.People.Doctors.Shared.DoctorStatusValues.DoctorStatuses.Available);

            doctorStatuses.Add
                (Domain.Entities.People.Doctors.Shared.DoctorStatusValues.DoctorStatuses.Busy);

            doctorStatuses.Add
                (Domain.Entities.People.Doctors.Shared.DoctorStatusValues.DoctorStatuses.Working);

            await _clinicsContext.SaveChangesAsync();
        }
    }
}
