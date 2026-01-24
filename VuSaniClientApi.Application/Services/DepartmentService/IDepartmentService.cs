using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<object> GetDepartmentsAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

