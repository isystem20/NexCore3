using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexDepartment.Dto
{
    public class DepartmentListDto : AuditableDto
    {
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public RecordStatus Status { get; set; }
        public string Description { get; set; }

    }
}
