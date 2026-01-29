using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class Disability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
      
        public bool Deleted { get; set; } = false;
        public int? Parent { get; set; }

        [ForeignKey(nameof(Parent))]
        public Disability? ParentDisability { get; set; }

        public ICollection<Disability>? Children { get; set; }

        public int IsStatic { get; set; } = 0;  // 1 = system, 0 = user created
    }

}
