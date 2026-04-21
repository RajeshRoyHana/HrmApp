using HrmApp.Repositories.Interfaces;
using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _repository;

        public CommonService(ICommonRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DropdownDto>> EducationExaminationsAsync(int clientId)
        {
            return await _repository.EducationExaminationsAsync(clientId);
        }

        public Task<List<DropdownDto>> EducationLevelsAsync(int clientId)
        {
            return _repository.EducationLevelsAsync(clientId);
        }

        public Task<List<DropdownDto>> GetDepartmentsAsync(int clientId)
        {
            return _repository.GetDepartmentsAsync(clientId);
        }

        public Task<List<DropdownDto>> GetDesignationsAsync(int clientId)
        {
            return _repository.GetDesignationsAsync(clientId);
        }

        public Task<List<DropdownDto>> GetEmployeeTypesAsync(int clientId)
        {
            return _repository.GetEmployeeTypesAsync(clientId);
        }

        public Task<List<DropdownDto>> GetGendersAsync(int clientId)
        {
            return _repository.GetGendersAsync(clientId);
        }

        public Task<List<DropdownDto>> GetJobTypesAsync(int clientId)
        {
            return _repository.GetJobTypesAsync(clientId);
        }

        public Task<List<DropdownDto>> GetMaritalStatusesAsync(int clientId)
        {
            return _repository.GetMaritalStatusesAsync(clientId);
        }

        public Task<List<DropdownDto>> GetReligionsAsync(int clientId)
        {
            return _repository.GetReligionsAsync(clientId);
        }

        public Task<List<DropdownDto>> GetSectionsAsync(int clientId)
        {
            return _repository.GetSectionsAsync(clientId);
        }

        public Task<List<DropdownDto>> GetWeeekOffsAsync(int clientId)
        {
            return _repository.GetWeeekOffsAsync(clientId);
        }

        public Task<List<DropdownDto>> RelationshipsAsync(int clientId)
        {
            return _repository.RelationshipsAsync(clientId);
        }
    }
}
