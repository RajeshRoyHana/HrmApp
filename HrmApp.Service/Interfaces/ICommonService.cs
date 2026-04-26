using HrmApp.Models.Entities;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services.Interfaces
{
    public interface ICommonService
    {
        Task<List<DropdownDto>> GetDepartmentsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetDesignationsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetSectionsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetGendersAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetJobTypesAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetEmployeeTypesAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetMaritalStatusesAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetReligionsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetWeeekOffsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> RelationshipsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> EducationExaminationsAsync(int idClient, CancellationToken cancellationToken);
        Task<List<DropdownDto>> EducationLevelsAsync(int idClient, CancellationToken cancellationToken);
    }
}
