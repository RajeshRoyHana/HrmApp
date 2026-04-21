using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services.Interfaces
{
    public interface ICommonService
    {
        Task<List<DropdownDto>> GetDepartmentsAsync(int clientId);
        Task<List<DropdownDto>> GetDesignationsAsync(int clientId);
        Task<List<DropdownDto>> GetSectionsAsync(int clientId);
        Task<List<DropdownDto>> GetGendersAsync(int clientId);
        Task<List<DropdownDto>> GetJobTypesAsync(int clientId);
        Task<List<DropdownDto>> GetEmployeeTypesAsync(int clientId);
        Task<List<DropdownDto>> GetMaritalStatusesAsync(int clientId);
        Task<List<DropdownDto>> GetReligionsAsync(int clientId);
        Task<List<DropdownDto>> GetWeeekOffsAsync(int clientId);
        Task<List<DropdownDto>> RelationshipsAsync(int clientId);
        Task<List<DropdownDto>> EducationExaminationsAsync(int clientId);
        Task<List<DropdownDto>> EducationLevelsAsync(int clientId);
    }
}
