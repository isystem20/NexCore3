using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace NEXARC.Domain.Entities.Payroll
{
    public class PayrollFrequency : AuditableEntity
    {
        // For test only; Replace with actual columns
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
