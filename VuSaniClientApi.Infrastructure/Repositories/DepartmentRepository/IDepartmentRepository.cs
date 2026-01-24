using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        Task<object> GetDepartmentsAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

