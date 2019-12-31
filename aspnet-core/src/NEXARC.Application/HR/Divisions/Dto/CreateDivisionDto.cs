using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexDivisions.Dto
{
	[AutoMapTo(typeof(Division))]
	public class CreateDivisionDto
	{

		[Required]
		public string Code { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

    }
}
