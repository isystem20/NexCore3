using Abp.Application.Services;
using NEXARC.NexDivisions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexDivisions
{
    public interface IDivisionAppService : IAsyncCrudAppService<DivisionDto, int, PagedDivisionResultRequestDto, CreateDivisionDto, UpdateDivisionDto>
    {

        //Put something if applicable

    }
}
