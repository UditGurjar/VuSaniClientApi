namespace VuSaniClientApi.Models.DTOs
{
    /// <summary>
    /// Request to set or remove employee login credentials (give/revoke software access).
    /// </summary>
    public class UpdateEmployeeCredentialDto
    {
        public int Id { get; set; }
        public string? Password { get; set; }
        public int? Organization { get; set; }
    }
}
