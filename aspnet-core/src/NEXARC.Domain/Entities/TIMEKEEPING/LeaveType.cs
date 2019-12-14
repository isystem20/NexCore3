using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.TIMEKEEPING
{
	public class LeaveType
	{
		public string Id { get; set; }
		public int TenantId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Remarks { get; set; }
		public bool IsPaid { get; set; }
		public bool IsStandard { get; set; }
		public int VersionNo { get; set; }
		public bool ShowOnKiosk { get; set; }
		public RecordStatus Status { get; set; }
	}
}
