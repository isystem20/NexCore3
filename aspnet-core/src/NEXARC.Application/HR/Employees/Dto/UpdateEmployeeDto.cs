using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
using NEXARC.Domain.Entities.HR;

namespace NEXARC.NexEmployee.Dto
{
	[AutoMapTo(typeof(Employee))]
	public class UpdateEmployeeDto : CreateEmployeeDto, IEntityDto
	{

		public int Id { get; set; }

	}
}
