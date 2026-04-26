using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services.Interfaces
{
    public interface IEmployeeService 
    {
        Task<IList<EmployeeListDto>> GetEmployeeListAsync(int idClient, CancellationToken cancellationToken);
        Task<int> CreateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken);
        Task<EmployeeDto?> GetEmployeeAsync(int idClient, int id, CancellationToken cancellationToken);
        Task<bool> DeleteEmployeeAsync(int idClient,int id, CancellationToken cancellationToken);
        Task<bool> UpdateEmployeeAsync(EmployeeDto dto, CancellationToken cancellationToken);
    }
}
