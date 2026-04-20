using HrmApp.Models.Entities;

namespace HrmApp.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetByClientIdAsync(int clientId);
    }
}
