using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using System;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexTeams.Dto
{
	[AutoMapFrom(typeof(Team))]
	public class TeamDto : EntityDto<int>
	{

		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

    }
}
