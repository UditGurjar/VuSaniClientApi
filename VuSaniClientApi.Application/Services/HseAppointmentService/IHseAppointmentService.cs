using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.HseAppointmentService
{
    public interface IHseAppointmentService
    {
        Task<object> GetHseAppointmentsAsync(int page, int pageSize, bool all, string search, string filter);
        Task<object> GetHseAppointmentByIdAsync(int id);
        Task<object> CreateUpdateHseAppointmentAsync(CreateUpdateHseAppointmentRequest request, int userId);
        Task<object> DeleteHseAppointmentAsync(int id, int userId);
        Task<object> UploadSignatureAsync(UploadHseAppointmentSignatureRequest request, int userId);
        Task<object> GetHseHierarchyAsync(int organizationId);
        Task<object> UpdateStatusAsync(UpdateHseAppointmentStatusRequest request, int userId);
        Task<object> RenewAppointmentAsync(RenewHseAppointmentRequest request, int userId);
    }
}
