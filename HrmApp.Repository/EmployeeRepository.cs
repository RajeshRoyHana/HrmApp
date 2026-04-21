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
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                .Include(e => e.EmployeeFamilyInfos)
                .Include(e => e.EmployeeProfessionalCertifications)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<EmployeeListDto>> GetEmployeeListByClientId(int clientId)
        {
            return await _context.Employees.Where(c => c.IdClient == clientId && c.IsActive == true)
                .GroupJoin(
                    _context.Designations,
                    a => a.IdDesignation,
                    d => d.Id,
                    (a, dGroup) => new { a, dGroup }
                )
                .SelectMany(
                    x => x.dGroup.DefaultIfEmpty(),
                    (x, d) => new EmployeeListDto
                    {
                        Id = x.a.IdClient,
                        ClientId = x.a.Id,
                        EmployeeName = x.a.EmployeeName,
                        DesignationName = d != null ? d.DesignationName : "N/A"
                    }
                )
                .ToListAsync();

        }

        public async Task<int> CreateAsync(Employee employee)
        {
             _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return false;

            employee.IsActive = false;
            employee.SetDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
