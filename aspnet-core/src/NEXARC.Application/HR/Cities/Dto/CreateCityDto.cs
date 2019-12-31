using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.NexCities.Dto
{
	[AutoMapTo(typeof(City))]
	public class CreateCityDto
	{

		[Required]
		public string Code { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

    }
}
