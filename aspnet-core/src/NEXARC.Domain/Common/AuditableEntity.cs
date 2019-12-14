using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Common
{
    public class AuditableEntity : Entity, IAudited
    {
        //Audit Creation
        public long? CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }

        //Audit Modification
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
