using NEXARC.NexCities.Dto;
using System.Collections.Generic;

namespace NEXARC.Web.Models.Cities
{
    public class CityListViewModel
    {
        public IReadOnlyList<CityDto> Cities { get; set; }

    }
}
