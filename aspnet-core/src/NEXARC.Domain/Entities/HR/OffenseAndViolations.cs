using NEXARC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
//using NEXARC.Domain.Entities.CommonResource;

namespace XERP.Domain.Entities.HumanResource
{
   public class LeaveTypes : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int VersionNo { get; set; }
        //public Company Companies { get; set; }
    }
}
