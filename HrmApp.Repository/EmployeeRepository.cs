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

        public async Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId)
        {
            return await _context.Employees.Where(c => c.IdClient == clientId)
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
    }
}
