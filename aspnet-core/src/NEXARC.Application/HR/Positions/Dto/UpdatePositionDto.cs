using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexPositions.Dto
{
	[AutoMapTo(typeof(Position))]
	public class UpdatePositionDto : CreatePositionDto, IEntityDto
	{

		public int Id { get; set; }

	}
}
