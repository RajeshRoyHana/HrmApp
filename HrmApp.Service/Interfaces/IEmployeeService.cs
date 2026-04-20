using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services.Interfaces
{
    public interface IEmployeeService 
    {
        Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId);
    }
}
