using NEXARC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.HumanResource
{
    /**
     * e.g. Valedictorian, Cum Laude, etc.
     */                                                                                                                                                                        
   public class EducationalAward : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VersionNo { get; set; }
        public string Status { get; set; }
    }
}
