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
        public async Task<List<DropdownDto>> EducationExaminationsAsync(int clientId, CancellationToken cancellationToken)
        {
            return await _repository.EducationExaminationsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> EducationLevelsAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.EducationLevelsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetDepartmentsAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetDepartmentsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetDesignationsAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetDesignationsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetEmployeeTypesAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetEmployeeTypesAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetGendersAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetGendersAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetJobTypesAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetJobTypesAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetMaritalStatusesAsync(int clientId,CancellationToken cancellationToken)
        {
            return _repository.GetMaritalStatusesAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetReligionsAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetReligionsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetSectionsAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.GetSectionsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> GetWeeekOffsAsync(int clientId,CancellationToken cancellationToken)
        {
            return _repository.GetWeeekOffsAsync(clientId, cancellationToken);
        }

        public Task<List<DropdownDto>> RelationshipsAsync(int clientId, CancellationToken cancellationToken)
        {
            return _repository.RelationshipsAsync(clientId, cancellationToken);
        }
    }
}
