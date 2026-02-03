using System.Collections.Generic;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.Repositories.SoftwareAccessRequestRepository
{
    public interface ISoftwareAccessRequestRepository
    {
        Task<(List<SoftwareAccessRequestListDto> Data, int Total)> GetAsync(int? id, int page, int pageSize, bool all, string? search, string? filter, int currentUserId);
        Task<SoftwareAccessRequest?> GetByIdAsync(int id);
        Task<SoftwareAccessRequest> CreateAsync(CreateUpdateSoftwareAccessRequestDto dto, int createdBy, string? uniqueId);
        Task<bool> UpdateAsync(CreateUpdateSoftwareAccessRequestDto dto, int updatedBy);
        Task<bool> UpdateStatusAsync(int id, string status, int updatedBy);
        Task<bool> DeleteAsync(int id);
    }
}
