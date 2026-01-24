using System;
using System.Collections.Generic;

namespace VuSaniClientApi.Models.DTOs
{
    public class SkillListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<int> Organization { get; set; } = new(); // Array for frontend filtering
        public string? SkillsType { get; set; }
        public string? Industry { get; set; }
        public int? IsStatic { get; set; }
        public string? UniqueId { get; set; }
        public int? CreatedBy { get; set; }
        public string? Created_by { get; set; }
        public string? Created_by_surname { get; set; }
        public int? Created_by_id { get; set; }
        public string? Created_by_profile { get; set; }
    }
}

