using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeeOffenseAndViolation : AuditableEntity
    {
        //public string ReferencedPolicy { get; set; }
        public OffenseAndViolationTrigger Trigger { get; set; }
        public string DetailsOfIncident { get; set; }
        public byte[] AttachmentFile { get; set; }
        public RecordStatus Status { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("OffenseAndViolationId")]
        public int OffenseAndViolationId { get; set; }
        public OffenseAndViolations OffenseAndViolation { get; set; }        
    }
}
