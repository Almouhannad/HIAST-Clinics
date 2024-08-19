using Domain.Entities.People.Patients;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IPatientsRepository : IRepository<Patient>
{
    #region Read operations FULL
    public Task<Result<Patient>> GetByIdFullAsync(int id);
    public Task<Result<ICollection<Patient>>> GetAllFullAsync(int id);

    #endregion
}
