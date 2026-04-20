using HrmApp.Models.Entities;
using HrmApp.Repositories.Interfaces;
using HrmApp.Services.Interfaces;
using HrmApp.Shared.Dtos;

namespace HrmApp.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Task<IList<EmployeeListDto>> GetEmployeeListByClientId(int clientId)
        {
            return _repository.GetEmployeeListByClientId(clientId);
        }
    }
}
