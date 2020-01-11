using NEXARC.NexTeams.Dto;
using System.Collections.Generic;

namespace NEXARC.Web.Models.Teams
{
    public class TeamListViewModel
    {
        public IReadOnlyList<TeamDto> Teams { get; set; }

    }
}
