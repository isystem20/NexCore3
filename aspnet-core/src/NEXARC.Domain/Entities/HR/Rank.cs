using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class Rank: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public RecordStatus Status { get; set; } //Double Check this record in the Office.
        public string Description { get; set; }
    }
}

/*
 Possible values are:
 Supervisor
 Rank and File
 Managers
     
*/