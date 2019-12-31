using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System;
using Abp.AutoMapper;
@AllNS

namespace {{Project}}.Nex{{EntityPlural}}.Dto
{
	[AutoMapTo(typeof({{Entity}}))]
	public class Update{{Entity}}Dto : Create{{Entity}}Dto, IEntityDto
	{

		public int Id { get; set; }

	}
}
