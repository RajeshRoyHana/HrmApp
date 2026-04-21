using HrmApp.Repositories.DataContext;
using HrmApp.Repositories.Interfaces;
using HrmApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HrmApp.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly AppDbContext _context;
        public CommonRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<DropdownDto>> EducationExaminationsAsync(int clientId)
        {
            return await _context.EducationExaminations
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(d => new DropdownDto
                                 {
                                     Value = d.Id,
                                     Text = d.ExamName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> EducationLevelsAsync(int clientId)
        {
            return await _context.EducationLevels
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.EducationLevelName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetDepartmentsAsync(int clientId)
        {
            return await _context.Departments
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.DepartName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetDesignationsAsync(int clientId)
        {
            return await _context.Designations
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.DesignationName

                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetEmployeeTypesAsync(int clientId)
        {
            return await _context.EmployeeTypes
                                  .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.TypeName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetGendersAsync(int clientId)
        {
            return await _context.Genders
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.GenderName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetJobTypesAsync(int clientId)
        {
            return await _context.JobTypes
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.JobTypeName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetMaritalStatusesAsync(int clientId)
        {
            return await _context.MaritalStatuses
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.MaritalStatusName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetReligionsAsync(int clientId)
        {
            return await _context.Religions
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.ReligionName
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetSectionsAsync(int clientId)
        {
            return await _context.Sections
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.SectionName

                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetWeeekOffsAsync(int clientId)
        {
            return await _context.WeekOffs
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.WeekOffDay
                                 })
                                 .ToListAsync();
        }

        public async Task<List<DropdownDto>> RelationshipsAsync(int clientId)
        {
            return await _context.Relationships
                                 .AsNoTracking()
                                 .Where(c => c.IdClient == clientId)
                                 .Select(s => new DropdownDto
                                 {
                                     Value = s.Id,
                                     Text = s.RelationName
                                 })
                                 .ToListAsync();
        }

    }
}
