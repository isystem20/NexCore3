using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using System;
@AllNS

namespace {{Project}}.Nex{{EntityPlural}}.Dto
{
	[AutoMapFrom(typeof({{Entity}}))]
	public class {{Entity}}Dto : EntityDto<int>
	{

        @EntityAttr

    }
}
