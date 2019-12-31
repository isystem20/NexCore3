using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using NEXARC.Authorization;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.NexCities.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using NEXARC.Common.Dto;

namespace NEXARC.NexCities
{
    [AbpAuthorize(PermissionNames.Pages_Cities)]
    public class CityAppService : AsyncCrudAppService<City, CityDto, int, PagedCityResultRequestDto, CreateCityDto, UpdateCityDto>, ICityAppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<City> _city;

        public CityAppService(IAbpSession abpSession, IRepository<City> city) : base(city)
        {
            _city = city;
            _abpSession = abpSession;
        }

        [AbpAuthorize("HR.City.Read")]
        protected override IQueryable<City> CreateFilteredQuery(PagedCityResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("HR.City.Create")]
        public override async Task<CityDto> CreateAsync(CreateCityDto input)
        {
            try
            {
                var entity = MapToEntity(input);

                await Repository.InsertAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                return MapToEntityDto(entity);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }


        }

        [AbpAuthorize("HR.City.Update")]
        public override async Task<CityDto> UpdateAsync(UpdateCityDto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("HR.City.Delete")]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var record = await _city.FirstOrDefaultAsync(input.Id);

            await _city.DeleteAsync(record);
        }

        [AbpAuthorize("HR.City.Delete")]
        public async Task DeleteMultipleAsync(MultipleId input)
        {
            foreach (var item in input.Id)
            {
                var record = await _city.FirstOrDefaultAsync(item);

                await _city.DeleteAsync(record);
            }
        }



        [AbpAuthorize("HR.City.Read")]
        protected override async Task<City> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
