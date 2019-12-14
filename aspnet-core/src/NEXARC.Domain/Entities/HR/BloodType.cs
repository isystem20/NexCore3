﻿using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class BloodType : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RecordStatus Status { get; set; }
    }
}