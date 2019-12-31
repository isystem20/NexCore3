using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexDivisions.Dto
{
	[AutoMapTo(typeof(Division))]
	public class UpdateDivisionDto : CreateDivisionDto, IEntityDto
	{

		public int Id { get; set; }

	}
}
