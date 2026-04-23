using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeListDto>> GetEmployeeListAsync(int clientId, CancellationToken cancellationToken);
        Task<Employee?> GetByIdAsync(int clientId, int id, CancellationToken cancellationToken);
        Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken);
        Task<bool> DeleteEmployeeAsync(int clientId, int id, CancellationToken cancellationToken);
        void RemoveEmployeeFamilyInfos(IEnumerable<EmployeeFamilyInfo> familyInfos);
        void RemoveEmployeeEducationInfos(IEnumerable<EmployeeEducationInfo> employeeEducationInfo);
        void RemoveEmployeeProfessionalCertifications(IEnumerable<EmployeeProfessionalCertification> employeeProfessionalCertifications);
        void RemoveEmployeeDocuments(IEnumerable<EmployeeDocument> employeeDocuments);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
