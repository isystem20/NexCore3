using NEXARC.Domain.Common;
using System;
using System.Collections.Generic;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class School : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int VersionNo { get; set; }

    }
}
