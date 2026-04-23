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
        public async Task<List<EmployeeListDto>> GetEmployeeListAsync(int clientId, CancellationToken cancellationToken)
        {

            return await _context.Employees
                .AsNoTracking()
                .Where(c => c.IdClient == clientId && c.IsActive == true)
                .Select(s => new EmployeeListDto
                {
                    Id = s.Id,
                    ClientId = s.IdClient,
                    EmployeeName = s.EmployeeName,
                    DesignationName = s.Designation != null ? s.Designation.DesignationName : "N/A"
                }).ToListAsync(cancellationToken);

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

       
        public async Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Add(employee);
            await SaveChangesAsync(cancellationToken);
            return employee.Id;
        }

        public async Task<bool> DeleteEmployeeAsync(int clientId,int id,CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.IdClient ==  clientId && e.Id == id &&  e.IsActive == true, cancellationToken);

            if (employee == null)
                return false;

            employee.IsActive = false;
            employee.SetDate = DateTime.UtcNow;

            await SaveChangesAsync(cancellationToken);
            return true;
        }

        public void RemoveEmployeeFamilyInfos(IEnumerable<EmployeeFamilyInfo> familyInfos)
        {
            _context.EmployeeFamilyInfos.RemoveRange(familyInfos);
        }

        public void RemoveEmployeeEducationInfos(IEnumerable<EmployeeEducationInfo> employeeEducationInfo)
        {
            _context.EmployeeEducationInfos.RemoveRange(employeeEducationInfo);
        }
        public void RemoveEmployeeDocuments(IEnumerable<EmployeeDocument> employeeDocuments)
        {
            _context.EmployeeDocuments.RemoveRange(employeeDocuments);
        }

        public void RemoveEmployeeProfessionalCertifications(IEnumerable<EmployeeProfessionalCertification> employeeProfessionalCertifications)
        {
            _context.EmployeeProfessionalCertifications.RemoveRange(employeeProfessionalCertifications);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
