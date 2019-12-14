using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeeRank : AuditableEntity
    {
        [ForeignKey("RankId")]
        public int RankId { get; set; }
        public Rank Rank { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
