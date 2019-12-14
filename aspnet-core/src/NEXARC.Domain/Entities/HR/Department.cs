using Abp.Domain.Entities.Auditing;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Entities.HR
{
    public class Department : AuditedEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public RecordStatus Status { get; set; }
        public string Description { get; set; }
    }
}
