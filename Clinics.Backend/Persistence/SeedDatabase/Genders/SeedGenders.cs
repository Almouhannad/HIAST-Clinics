using Domain.Entities.People.Shared.GenderValues;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.SeedDatabase;

namespace Persistence.Seed.Genders;

public class SeedGenders : ISeed<Gender>
{
    #region Ctor DI
    private readonly ClinicsDbContext _clinicsContext;

    public SeedGenders(ClinicsDbContext clinicsContext)
    {
        _clinicsContext = clinicsContext;
    }
    #endregion

    public async Task Seed()
    {
        DbSet<Gender> Genders = _clinicsContext.Set<Gender>();

        if (Genders.ToList().Count !=
            Domain.Entities.People.Shared.GenderValues.Genders.Count)
        {
            Genders.RemoveRange(Genders.ToList());

            Genders
                .Add(Domain.Entities.People.Shared.GenderValues.Genders.Male);

            Genders
                .Add(Domain.Entities.People.Shared.GenderValues.Genders.Female);

            await _clinicsContext.SaveChangesAsync();
        }
    }
}
