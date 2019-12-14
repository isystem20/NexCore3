using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeeAttachment : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] AttachmentFile { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
