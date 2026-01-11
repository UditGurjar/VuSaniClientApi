using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class HighestQualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        // JSON like [3,2,1]
        public string? Organization { get; set; }

        public int? Deleted { get; set; } = 0;

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        [StringLength(250)]
        public string? UniqueId { get; set; }
    }
}
