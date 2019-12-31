using Abp.Application.Services;
using NEXARC.NexCities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexCities
{
    public interface ICityAppService : IAsyncCrudAppService<CityDto, int, PagedCityResultRequestDto, CreateCityDto, UpdateCityDto>
    {

        //Put something if applicable

    }
}
