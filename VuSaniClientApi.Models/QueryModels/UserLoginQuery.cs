using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.QueryModels
{
    public class UserLoginQuery
    {
        [Required]
        public string Field { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
