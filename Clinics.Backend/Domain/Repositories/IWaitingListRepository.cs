using Domain.Entities.WaitingList;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IWaitingListRepository : IRepository<WaitingListRecord>
{
    public Task<Result<bool>> IsEmployeeInWaitingListAsync(string serialNumber);
}
