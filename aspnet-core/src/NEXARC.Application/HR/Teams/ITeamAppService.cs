using Abp.Application.Services;
using NEXARC.NexTeams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexTeams
{
    public interface ITeamAppService : IAsyncCrudAppService<TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, UpdateTeamDto>
    {

        //Put something if applicable

    }
}
