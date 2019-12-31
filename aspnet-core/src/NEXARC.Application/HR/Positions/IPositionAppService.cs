using Abp.Application.Services;
using NEXARC.NexPositions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexPositions
{
    public interface IPositionAppService : IAsyncCrudAppService<PositionDto, int, PagedPositionResultRequestDto, CreatePositionDto, UpdatePositionDto>
    {

        //Put something if applicable

    }
}
