using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Repositories.Interfaces
{
    public interface IEmployeeRepository 
    {
        Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId);
    }
}
