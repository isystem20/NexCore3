using Abp.Application.Services;
using NEXARC.NexRanks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexRanks
{
    public interface IRankAppService : IAsyncCrudAppService<RankDto, int, PagedRankResultRequestDto, CreateRankDto, UpdateRankDto>
    {

        //Put something if applicable

    }
}
