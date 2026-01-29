namespace VuSaniClientApi.Models.DTOs
{
    public class DisabilityListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Parent { get; set; }
        public int IsStatic { get; set; }
    }
}
