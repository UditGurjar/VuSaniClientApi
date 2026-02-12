using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.HseAppointmentRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.HseAppointmentService
{
    public class HseAppointmentService : IHseAppointmentService
    {
        private readonly IHseAppointmentRepository _hseAppointmentRepository;

        public HseAppointmentService(IHseAppointmentRepository hseAppointmentRepository)
        {
            _hseAppointmentRepository = hseAppointmentRepository;
        }

        public async Task<object> GetHseAppointmentsAsync(int page, int pageSize, bool all, string search, string filter)
        {
            return await _hseAppointmentRepository.GetHseAppointmentsAsync(page, pageSize, all, search, filter);
        }

        public async Task<object> GetHseAppointmentByIdAsync(int id)
        {
            return await _hseAppointmentRepository.GetHseAppointmentByIdAsync(id);
        }

        public async Task<object> CreateUpdateHseAppointmentAsync(CreateUpdateHseAppointmentRequest request, int userId)
        {
            // If ID is provided, it's an update; otherwise, it's a create
            if (request.Id.HasValue && request.Id.Value > 0)
            {
                return await _hseAppointmentRepository.UpdateHseAppointmentAsync(request, userId);
            }
            else
            {
                return await _hseAppointmentRepository.CreateHseAppointmentAsync(request, userId);
            }
        }

        public async Task<object> DeleteHseAppointmentAsync(int id, int userId)
        {
            return await _hseAppointmentRepository.DeleteHseAppointmentAsync(id, userId);
        }

        public async Task<object> UploadSignatureAsync(UploadHseAppointmentSignatureRequest request, int userId)
        {
            return await _hseAppointmentRepository.UploadSignatureAsync(request, userId);
        }

        public async Task<object> GetHseHierarchyAsync(int organizationId)
        {
            return await _hseAppointmentRepository.GetHseHierarchyAsync(organizationId);
        }

        public async Task<object> UpdateStatusAsync(UpdateHseAppointmentStatusRequest request, int userId)
        {
            return await _hseAppointmentRepository.UpdateStatusAsync(request, userId);
        }

        public async Task<object> RenewAppointmentAsync(RenewHseAppointmentRequest request, int userId)
        {
            return await _hseAppointmentRepository.RenewAppointmentAsync(request, userId);
        }

        public async Task<object> AcceptByTokenAsync(string token)
        {
            return await _hseAppointmentRepository.AcceptByTokenAsync(token);
        }

        public async Task<object> RejectByTokenAsync(string token, string rejectionReason)
        {
            return await _hseAppointmentRepository.RejectByTokenAsync(token, rejectionReason);
        }
    }
}
