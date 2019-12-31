using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexRanks.Dto
{
	[AutoMapTo(typeof(Rank))]
	public class CreateRankDto
	{

		[Required]
		public string Code { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

    }
}
