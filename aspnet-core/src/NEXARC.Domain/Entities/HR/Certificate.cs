using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System.Collections.Generic;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class Certificate: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public RecordStatus Status { get; set; } // Check Record Status Enum
        public string Description { get; set; }

        public ICollection<EmployeeCertificate> EmployeeCertificates { get; set; }
    }
}
