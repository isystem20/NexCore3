using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexTeams.Dto
{
	[AutoMapTo(typeof(Team))]
	public class UpdateTeamDto : CreateTeamDto, IEntityDto
	{

		public int Id { get; set; }

	}
}
