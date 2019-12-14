using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System.Collections.Generic;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class Division: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public RecordStatus Status { get; set; } //Double Check this record in the Office.
        public string Description { get; set; }
    }
}
