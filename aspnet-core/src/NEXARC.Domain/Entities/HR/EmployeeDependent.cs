using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeeDependent : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DependentRelation Relation { get; set; }
        public DateTime Birthdate { get; set; }
        public int VersionNo { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
