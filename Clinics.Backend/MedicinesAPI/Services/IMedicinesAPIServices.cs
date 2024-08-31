using Domain.Entities.Medicals.Medicines;
using Domain.Shared;

namespace MedicinesAPI.Services;

public interface IMedicinesAPIServices
{
    public Task<Result<ICollection<Medicine>>> GetAll();
}
