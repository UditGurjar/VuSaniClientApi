using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.AppointmentTypeRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.AppointmentTypeService
{
    public class AppointmentTypeService : IAppointmentTypeService
    {
        private readonly IAppointmentTypeRepository _appointmentTypeRepository;

        public AppointmentTypeService(IAppointmentTypeRepository appointmentTypeRepository)
        {
            _appointmentTypeRepository = appointmentTypeRepository;
        }

        public async Task<object> GetAppointmentTypesAsync(int page, int pageSize, bool all, string search)
        {
            return await _appointmentTypeRepository.GetAppointmentTypesAsync(page, pageSize, all, search);
        }

        public async Task<object> GetAppointmentTypeByIdAsync(int id)
        {
            return await _appointmentTypeRepository.GetAppointmentTypeByIdAsync(id);
        }

        public async Task<object> CreateUpdateAppointmentTypeAsync(CreateUpdateAppointmentTypeRequest request, int userId)
        {
            return await _appointmentTypeRepository.CreateUpdateAppointmentTypeAsync(request, userId);
        }

        public async Task<object> DeleteAppointmentTypeAsync(int id, int userId)
        {
            return await _appointmentTypeRepository.DeleteAppointmentTypeAsync(id, userId);
        }
    }
}
