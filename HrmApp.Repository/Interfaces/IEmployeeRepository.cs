using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Repositories.Interfaces
{
    public interface IEmployeeRepository 
    {
        Task<List<EmployeeListDto>> GetEmployeeListByClientId(int clientId);
        Task<int> CreateAsync(Employee employee);
        Task<Employee?> GetByIdAsync(int id);
        Task<bool> DeleteEmployee(int id);
    }
}
