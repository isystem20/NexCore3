using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class Barangay : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ZipCode { get; set; }
        public RecordStatus Status { get; set; }
    }
}
