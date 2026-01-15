using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Models.DTOs
{
    public class AuthResponseDTO
    {
        public bool Status { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public UserDetailsDto User { get; set; }
    }
}
