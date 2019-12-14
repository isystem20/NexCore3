using NEXARC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.TIMEKEEPING
{
    public class LeaveFiling : AuditableEntity
    {
        public string ReferenceNumber { get; set; }
        public int TenantId { get; set; }
        public DateTime WorkDate { get; set; }
        public float? Quantity { get; set; }
        public int LeaveFilingQuantityTypeId { get; set; }
        public int FilingStatusId { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public bool Posted { get; set; }
        public int VersionNo { get; set; }
        public int ApproverLevel { get; set; }
        public bool IsPaid { get; set; }
        public string Reason { get; set; }
}
}
