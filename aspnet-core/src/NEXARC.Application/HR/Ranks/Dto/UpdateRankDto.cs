using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexRanks.Dto
{
	[AutoMapTo(typeof(Rank))]
	public class UpdateRankDto : CreateRankDto, IEntityDto
	{

		public int Id { get; set; }

	}
}
