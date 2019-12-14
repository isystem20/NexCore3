using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXARC.Domain.Entities.HR
{
    public class EmployeeState: AuditableEntity
    {
        //public ChangeStateType ChangeType { get; set; } //Double check on EmployeeStateChangeType worked by Ollea
        public string Description { get; set; }
        public DateTime EffectivityDate { get; set; }
        public DateTime? HiredDate { get; set; }
        public DateTime? RegularDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }

        //USE IN HR
        [ForeignKey("SiteId")]
        public Site Site { get; set; }
        public int SiteId { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("DivisionId")]
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("SectionId")]
        public int SectionId { get; set; }
        public Section Section { get; set; }

        [ForeignKey("CostCenterId")]
        public int CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }

        [ForeignKey("PositionId")]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [ForeignKey("EmploymentTypeId")]
        public int EmploymentTypeId { get; set; }
        public EmploymentType EmploymentType { get; set; }

        [ForeignKey("RankId")]
        public int RankId { get; set; }
        public Rank Rank { get; set; }

        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        
        public RecordStatus Status { get; set; } //Double Check
        
    }
}
