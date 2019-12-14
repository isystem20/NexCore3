using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.HR.Employees.Dto
{
    [AutoMapFrom(typeof(EmployeeState))]
    public class EmployeeStateDto : EntityDto<int>
    {
        public string Description { get; set; }
        public DateTime EffectivityDate { get; set; }

        public DateTime? HiredDate { get; set; }
        public DateTime? RegularDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }


        //USE IN HR
        public string CompanyId { get; set; }
        public string SiteId { get; set; }
        //public virtual string EmployeeId { get; set; }
        public string DivisionId { get; set; }
        //public virtual string DepartmentId { get; set; }
        public string SectionId { get; set; }
        public string CostCenterId { get; set; }
        public string PositionId { get; set; }
        public string EmploymentTypeId { get; set; }
        public string RankId { get; set; }
        public string GroupId { get; set; }


        public RecordStatus Status { get; set; } //Double Check
        //public Site Site { get; set; }
        //[NotMapped]
        public Department Department { get; set; }
    }
}
