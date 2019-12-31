using NEXARC.NexDivisions.Dto;
using System.Collections.Generic;

namespace NEXARC.Web.Models.Divisions
{
    public class DivisionListViewModel
    {
        public IReadOnlyList<DivisionDto> Divisions { get; set; }

    }
}
