using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeeEducationalBackGround : AuditableEntity //, IMustHaveTenant
    {
        public string School { get; set; }
        public string Program { get; set; }
        public EducationalLevel EducationalLevel { get; set; }
        public GraduateStatus GraduateStatus { get; set; }
        public string InclusiveDateFrom { get; set; }
        public string InclusiveDateTo { get; set; }
        public string Remarks { get; set; }
        public int VersionNo { get; set; }
        public string EducationalAward { get; set; }
               
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
