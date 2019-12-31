using Abp.Application.Services;
using {{Project}}.Nex{{EntityPlural}}.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{Project}}.Nex{{EntityPlural}}
{
    public interface I{{Entity}}AppService : IAsyncCrudAppService<{{Entity}}Dto, int, Paged{{Entity}}ResultRequestDto, Create{{Entity}}Dto, Update{{Entity}}Dto>
    {

        //Put something if applicable

    }
}
