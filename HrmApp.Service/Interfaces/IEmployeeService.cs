using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services.Interfaces
{
    public interface IEmployeeService 
    {
        Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId, CancellationToken cancellationToken);
        Task<int> CreateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken);
        Task<EmployeeDto?> GetEmployeeAsync(int clientId, int id, CancellationToken cancellationToken);
        Task<bool> DeleteEmployee(int clientId,int id, CancellationToken cancellationToken);
        Task<bool> UpdateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken);
    }
}
