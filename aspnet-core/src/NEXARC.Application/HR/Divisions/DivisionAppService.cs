using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using NEXARC.Authorization;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.NexDivisions.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;

namespace NEXARC.NexDivisions
{
    [AbpAuthorize("HR.Division")]
    public class DivisionAppService : AsyncCrudAppService<Division, DivisionDto, int, PagedDivisionResultRequestDto, CreateDivisionDto, UpdateDivisionDto>, IDivisionAppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<Division> _division;

        public DivisionAppService(IAbpSession abpSession, IRepository<Division> division) : base(division)
        {
            _division = division;
            _abpSession = abpSession;
        }

        [AbpAuthorize("HR.Division.Read")]
        protected override IQueryable<Division> CreateFilteredQuery(PagedDivisionResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("HR.Division.Create")]
        public override async Task<DivisionDto> CreateAsync(CreateDivisionDto input)
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

        [AbpAuthorize("HR.Division.Update")]
        public override async Task<DivisionDto> UpdateAsync(UpdateDivisionDto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("HR.Division.Delete")]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var record = await _division.FirstOrDefaultAsync(input.Id);

            await _division.DeleteAsync(record);
        }

        [AbpAuthorize("HR.Division.Read")]
        protected override async Task<Division> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
