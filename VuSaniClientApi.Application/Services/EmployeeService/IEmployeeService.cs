using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<object> GetEmployeesAsync(int page, int pageSize, bool all, string search, string filter);
        Task<object> GetEmployeeByIdAsync(int id);
        Task<object> CreateEmployeeAsync(CreateUpdateEmployeeRequest request, int userId);
        Task<object> UpdateEmployeeAsync(CreateUpdateEmployeeRequest request, int userId);
        Task<object> DeleteEmployeeAsync(int id, int userId);
    }
}

