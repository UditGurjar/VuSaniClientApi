using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.HseAppointmentRepository
{
    public interface IHseAppointmentRepository
    {
        Task<object> GetHseAppointmentsAsync(int page, int pageSize, bool all, string search, string filter);
        Task<object> GetHseAppointmentByIdAsync(int id);
        Task<object> CreateHseAppointmentAsync(CreateUpdateHseAppointmentRequest request, int userId);
        Task<object> UpdateHseAppointmentAsync(CreateUpdateHseAppointmentRequest request, int userId);
        Task<object> DeleteHseAppointmentAsync(int id, int userId);
        Task<object> UploadSignatureAsync(UploadHseAppointmentSignatureRequest request, int userId);
        Task<object> GetHseHierarchyAsync(int organizationId);
        Task<object> UpdateStatusAsync(UpdateHseAppointmentStatusRequest request, int userId);
        Task<object> RenewAppointmentAsync(RenewHseAppointmentRequest request, int userId);
        Task<object> AcceptByTokenAsync(string token);
        Task<object> RejectByTokenAsync(string token, string rejectionReason);
    }
}
