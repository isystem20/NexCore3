using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
@AllNS

namespace {{Project}}.Nex{{EntityPlural}}.Dto
{
	[AutoMapTo(typeof({{Entity}}))]
	public class Create{{Entity}}Dto
	{

		@EntityRequiredAttr

    }
}
