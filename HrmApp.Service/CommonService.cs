using HrmApp.Services.DataContext;
using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HrmApp.Services
{
    public class CommonService : ICommonService
    {
        private readonly AppDbContext _context;
        public CommonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<DropdownDto>> EducationExaminationsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.EducationExaminations
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(d => new DropdownDto
                                 {
                                     Value = d.Id,
                                     Text = d.ExamName ?? string.Empty,
                                 }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> EducationLevelsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.EducationLevels
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.EducationLevelName ?? string.Empty
                                 }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetDepartmentsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Departments
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.DepartName ?? string.Empty
                                 }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetDesignationsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Designations
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.DesignationName ?? string.Empty

                                 }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetEmployeeTypesAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.EmployeeTypes
                                  .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.TypeName ?? string.Empty
                                 }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetGendersAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Genders
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.GenderName ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetJobTypesAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.JobTypes
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.JobTypeName ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetMaritalStatusesAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.MaritalStatuses
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.MaritalStatusName ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetReligionsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Religions
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.ReligionName ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetSectionsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Sections
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.SectionName ?? string.Empty

                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> GetWeeekOffsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.WeekOffs
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.WeekOffDay ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<DropdownDto>> RelationshipsAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.Relationships
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.RelationName ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }
        public async Task<List<DropdownDto>> GetEducationResultAsync(int idClient, CancellationToken cancellationToken)
        {
            var data = await _context.EducationResults
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == idClient)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.ResultName ?? string.Empty
                                 })
                                 .ToListAsync(cancellationToken);
            return data;
        }
    }
}
