using HrmApp.Models.Entities;
using HrmApp.Repositories.DataContext;
using HrmApp.Repositories.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HrmApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee?> GetByIdAsync(int clientId, int id,CancellationToken cancellationToken)
        {
            return await _context.Employees
                //.AsNoTracking()
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeFamilyInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .FirstOrDefaultAsync(e => e.Id == id && e.IdClient == clientId, cancellationToken);
        }

        public async Task<List<EmployeeListDto>> GetEmployeeListByClientId(int clientId, CancellationToken cancellationToken)
        {

            return await _context.Employees
                .AsNoTracking()
                .Where(c => c.IdClient == clientId && c.IsActive == true)
                .Include(d => d.Designation)
                .Select(s => new EmployeeListDto
                {
                    Id = s.IdClient,
                    ClientId = s.Id,
                    EmployeeName = s.EmployeeName,
                    DesignationName = s.Designation != null ? s.Designation.DesignationName : "N/A"
                }).ToListAsync(cancellationToken);

        }

        public async Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken)
        {
             _context.Employees.Add(employee);
            await SaveChangesAsync(cancellationToken);
            return employee.Id;
        }

        public async Task<bool> DeleteEmployee(int clientId,int id,CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.IdClient ==  clientId && e.Id == id, cancellationToken);

            if (employee == null)
                return false;

            employee.IsActive = false;
            employee.SetDate = DateTime.UtcNow;

            await SaveChangesAsync(cancellationToken);
            return true;
        }

        public Task RemoveEmployeeFamilyInfosAsync(IEnumerable<EmployeeFamilyInfo> familyInfos, CancellationToken cancellationToken)
        {
            _context.EmployeeFamilyInfos.RemoveRange(familyInfos);
            return Task.CompletedTask;
        }

        public Task RemoveEmployeeEducationInfosAsync(IEnumerable<EmployeeEducationInfo> employeeEducationInfo, CancellationToken cancellationToken)
        {
            _context.EmployeeEducationInfos.RemoveRange(employeeEducationInfo);
            return Task.CompletedTask;
        }
        public Task RemoveEmployeeDocumentsAsync(IEnumerable<EmployeeDocument> employeeDocuments, CancellationToken cancellationToken)
        {
            _context.EmployeeDocuments.RemoveRange(employeeDocuments);
            return Task.CompletedTask;
        }

        public Task RemoveEmployeeProfessionalCertificationsAsync(IEnumerable<EmployeeProfessionalCertification> employeeProfessionalCertifications, CancellationToken cancellationToken)
        {
            _context.EmployeeProfessionalCertifications.RemoveRange(employeeProfessionalCertifications);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
