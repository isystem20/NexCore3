using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Configuration.Dto
{
    public class ToggleLeftSideBarInput
    {
        [Required]
        [StringLength(32)]
        public string State { get; set; }
    }
}
