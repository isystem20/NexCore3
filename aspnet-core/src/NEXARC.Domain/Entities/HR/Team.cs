using NEXARC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class Team : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VersionNo { get; set; }
    }
}
