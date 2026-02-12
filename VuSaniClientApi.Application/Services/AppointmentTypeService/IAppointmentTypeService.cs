using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.AppointmentTypeService
{
    public interface IAppointmentTypeService
    {
        Task<object> GetAppointmentTypesAsync(int page, int pageSize, bool all, string search);
        Task<object> GetAppointmentTypeByIdAsync(int id);
        Task<object> CreateUpdateAppointmentTypeAsync(CreateUpdateAppointmentTypeRequest request, int userId);
        Task<object> DeleteAppointmentTypeAsync(int id, int userId);
    }
}
