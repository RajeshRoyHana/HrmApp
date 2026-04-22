using HrmApp.Shared.Dtos;

namespace HrmApp.Repositories.Interfaces
{
    public interface ICommonRepository
    {
        Task<List<DropdownDto>> GetDepartmentsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetDesignationsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetSectionsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetGendersAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetJobTypesAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetEmployeeTypesAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetMaritalStatusesAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetReligionsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> GetWeeekOffsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> RelationshipsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> EducationExaminationsAsync(int clientId, CancellationToken cancellationToken);
        Task<List<DropdownDto>> EducationLevelsAsync(int clientId, CancellationToken cancellationToken);
    }
}
