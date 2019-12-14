using NEXARC.Domain.Enumerations;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using System;
using NEXARC.Domain.Entities.HR;

namespace NEXARC.NexDepartment.Dto
{
	[AutoMapFrom(typeof(Department))]
	public class DepartmentDto : EntityDto<int>
	{

        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public RecordStatus Status { get; set; }
        public string Description { get; set; }

    }
}
