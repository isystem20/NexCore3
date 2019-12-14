using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.TIMEKEEPING
{
    public class OTFiling
    {
        public string ReferenceNumber { get; set; }
        public int EmployeeId { get; set; }
        public int TenantId { get; set; }
        public int FilingStatusId { get; set; }
        public DateTime WorkDate { get; set; }
        public float HoursFiled { get; set; }
        public float HoursApproved { get; set; }
        public bool Posted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Reason { get; set; }
        public int VersionNo { get; set; }
        public bool IsConvertToLeave { get; set; }
        public float? HoursConvertedToLeave { get; set; }
        public int ApproverLevel { get; set; }
        public int? ConvertedLeaveTypeId { get; set; } //Leave Type To use

    }
}
