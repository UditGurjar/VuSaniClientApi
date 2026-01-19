using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class Sidebar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(500)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Icon { get; set; }

        [StringLength(500)]
        public string? Path { get; set; }

        public SidebarType Type { get; set; } = SidebarType.Module;

        public bool Deleted { get; set; } = false;

        public int ParentId { get; set; } = 0;

      
        public int? Sequence { get; set; }

      
        [StringLength(500)]
        public string? TableName { get; set; }

 
        [StringLength(500)]
        public string? Comment { get; set; }


        public int? DependentModule { get; set; }


        public string? Dependency { get; set; }
    }
    public enum SidebarType
    {
        Module,
        Tab,
        SubTab
    }

}
