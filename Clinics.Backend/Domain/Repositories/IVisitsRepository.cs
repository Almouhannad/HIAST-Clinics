using Domain.Entities.Visits;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IVisitsRepository : IRepository<Visit>
{

	#region Get all by patient id
	public Task<Result<ICollection<Visit>>> GetAllByPatientIdAsync(int patientId);
	#endregion

}
