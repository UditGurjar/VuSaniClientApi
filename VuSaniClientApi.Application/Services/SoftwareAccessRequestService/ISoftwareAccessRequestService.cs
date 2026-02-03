using System.Collections.Generic;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.SoftwareAccessRequestService
{
    public interface ISoftwareAccessRequestService
    {
        Task<(object Data, int Total)> GetAsync(int? id, int page, int pageSize, bool all, string? search, string? filter, int currentUserId);
        Task<bool> CreateUpdateAsync(CreateUpdateSoftwareAccessRequestDto dto, int currentUserId);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateStatusAsync(UpdateAccessRequestStatusDto dto, int currentUserId);
    }
}
