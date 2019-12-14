using NEXARC.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXARC.Domain.Entities.TIMEKEEPING
{
    public class LeaveFiling : AuditableEntity
    {
        public string Id { get; set; }
        public string RefNum { get; set; }
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
        //public IsPosted { get; set; }
        //public int? ApprovedById { get; set; }
        //public DateTime? ApprovalDate { get; set; }
        //public int LeaveTypeId { get; set; }
        //public DateTime? CreationDate { get; set; }
        //public int? CreatedById { get; set; }
        //public int? ModifiedById { get; set; }
        //public DateTime? ModificationDate { get; set; }
        //public int? MarkerTypeId { get; set; }
        //public string Reason { get; set; }
        //public int? UIID { get; set; }
        //public IsPaid { get; set; }
        //public int? LeaveFilingQuantityId { get; set; }
        //public int NextSequenceNo { get; set; }
        //public Approved { get; set; }
        //public string ApproverRemarks { get; set; }
        //public DateTime? DateFiled { get; set; }
        //public int? LeaveFilingSourceId { get; set; }
        //public float? CreditedQuantity { get; set; }
        public string Reason { get; set; }
}
}
