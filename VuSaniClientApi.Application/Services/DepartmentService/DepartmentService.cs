using System;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.DepartmentRepository;

namespace VuSaniClientApi.Application.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<object> GetDepartmentsAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            try
            {
                return await _departmentRepository.GetDepartmentsAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

