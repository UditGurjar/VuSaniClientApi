namespace VuSaniClientApi.Models.DTOs
{
    /// <summary>
    /// Response for delete employee API. Matches Node.js sendResponse shape: { status, message }.
    /// </summary>
    public class DeleteEmployeeResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
