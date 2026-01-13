using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class NextOfKin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int NextOfKinId { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public int? RelationshipId { get; set; }
        [ForeignKey(nameof(RelationshipId))]
        public RelationShip? RelationShip { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
     
    }
}
