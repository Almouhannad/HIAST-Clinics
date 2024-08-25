using Domain.Entities.Identity.Users;
using Domain.Entities.People.Doctors;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IDoctorsRepository : IRepository<Doctor>
{
	#region Get available
	public Task<Result<ICollection<Doctor>>> GetAvailableDoctors();
	#endregion

	#region Get user
	public Task<Result<DoctorUser>> GetUserByIdAsync(int id);
	#endregion
}
