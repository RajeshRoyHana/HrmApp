using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services.Interfaces
{
    public interface IEmployeeService 
    {
        Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId);
        Task<int> CreateEmployeeAsync(EmployeeDto dto);
        Task<EmployeeDto?> GetEmployeeAsync(int id);
        Task<bool> DeleteEmployee(int id);
    }
}
