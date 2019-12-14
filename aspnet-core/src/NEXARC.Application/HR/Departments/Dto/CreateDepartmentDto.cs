using NEXARC.Domain.Enumerations;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using NEXARC.Domain.Entities.HR;

namespace NEXARC.NexDepartment.Dto
{
	[AutoMapTo(typeof(Department))]
	public class CreateDepartmentDto
	{

		[Required]
        public int CompanyId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RecordStatus Status { get; set; }
        public string Description { get; set; }

    }
}
