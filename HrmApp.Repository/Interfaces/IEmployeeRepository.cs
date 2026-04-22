using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeListDto>> GetEmployeeListByClientId(int clientId, CancellationToken cancellationToken);
        Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee?> GetByIdAsync(int clientId, int id, CancellationToken cancellationToken);
        Task<bool> DeleteEmployee(int clientId, int id, CancellationToken cancellationToken);

        Task RemoveEmployeeFamilyInfosAsync(IEnumerable<EmployeeFamilyInfo> familyInfos, CancellationToken cancellationToken);
        Task RemoveEmployeeEducationInfosAsync(IEnumerable<EmployeeEducationInfo> employeeEducationInfo, CancellationToken cancellationToken);
        Task RemoveEmployeeProfessionalCertificationsAsync(IEnumerable<EmployeeProfessionalCertification> employeeProfessionalCertifications, CancellationToken cancellationToken);
        Task RemoveEmployeeDocumentsAsync(IEnumerable<EmployeeDocument> employeeDocuments, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
