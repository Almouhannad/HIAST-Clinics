using Domain.Entities.Medicals.Medicines;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IMedicinesRepository : IRepository<Medicine>
{

	#region Get all with prefix
	public Task<Result<ICollection<Medicine>>> GetAllWithPrefix(string? prefix = null);
	#endregion
}
