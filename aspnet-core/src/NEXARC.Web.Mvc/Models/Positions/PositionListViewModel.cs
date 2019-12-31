using NEXARC.NexPositions.Dto;
using System.Collections.Generic;

namespace NEXARC.Web.Models.Positions
{
    public class PositionListViewModel
    {
        public IReadOnlyList<PositionDto> Positions { get; set; }

    }
}
