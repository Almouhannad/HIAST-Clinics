using Domain.Entities.People.Employees;
using Domain.Entities.People.FamilyMembers;
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

    #region IsEmployee
    public Task<Result<bool>> IsEmployeeByIdAsync(int id);
    public Task<Result<Employee>> GetEmployeeByIdAsync(int id);
    #endregion

    #region FamilyMember
    public Task<Result<bool>> IsFamilyMemberByIdAsync(int id);
    public Task<Result<FamilyMember>> GetFamilyMemberByIdAsync(int id);
    #endregion

}
