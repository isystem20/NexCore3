using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexCities.Dto
{
	[AutoMapTo(typeof(City))]
	public class UpdateCityDto : CreateCityDto, IEntityDto
	{

		public int Id { get; set; }

	}
}
