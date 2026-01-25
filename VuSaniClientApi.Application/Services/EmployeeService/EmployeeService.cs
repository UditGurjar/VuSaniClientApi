using System;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.EmployeeRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<object> GetEmployeesAsync(int page, int pageSize, bool all, string search, string filter)
        {
            try
            {
                return await _employeeRepository.GetEmployeesAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _employeeRepository.GetEmployeeByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> CreateEmployeeAsync(CreateUpdateEmployeeRequest request, int userId)
        {
            try
            {
                return await _employeeRepository.CreateEmployeeAsync(request, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> UpdateEmployeeAsync(CreateUpdateEmployeeRequest request, int userId)
        {
            try
            {
                return await _employeeRepository.UpdateEmployeeAsync(request, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> DeleteEmployeeAsync(int id, int userId)
        {
            try
            {
                return await _employeeRepository.DeleteEmployeeAsync(id, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

