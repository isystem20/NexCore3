using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.TIMEKEEPING
{
	public class OBFiling
	{
		public string ReferenceNumber { get; set; }
		public int EmployeeId { get; set; }
		public int TenantId { get; set; }
		public DateTime WorkDate { get; set; }
		public DateTime? TimeIn { get; set; }
		public DateTime? TimeOut { get; set; }
		public float HoursFiled { get; set; }
		public float HoursApproved { get; set; }
		public int FilingStatusId { get; set; }
		public string Reason { get; set; }
		public bool Posted { get; set; }
        public int VersionNo { get; set; }
        public int ApproverLevel { get; set; }
		public bool IsPaid { get; set; }
    }
}
