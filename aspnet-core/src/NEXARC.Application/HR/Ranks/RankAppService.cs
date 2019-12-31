using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using NEXARC.Authorization;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.NexRanks.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using NEXARC.Common.Dto;

namespace NEXARC.NexRanks
{
    [AbpAuthorize("HR.Rank")]
    public class RankAppService : AsyncCrudAppService<Rank, RankDto, int, PagedRankResultRequestDto, CreateRankDto, UpdateRankDto>, IRankAppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<Rank> _rank;

        public RankAppService(IAbpSession abpSession, IRepository<Rank> rank) : base(rank)
        {
            _rank = rank;
            _abpSession = abpSession;
        }

        [AbpAuthorize("HR.Rank.Read")]
        protected override IQueryable<Rank> CreateFilteredQuery(PagedRankResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("HR.Rank.Create")]
        public override async Task<RankDto> CreateAsync(CreateRankDto input)
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

        [AbpAuthorize("HR.Rank.Update")]
        public override async Task<RankDto> UpdateAsync(UpdateRankDto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("HR.Rank.Delete")]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var record = await _rank.FirstOrDefaultAsync(input.Id);

            await _rank.DeleteAsync(record);
        }


		[AbpAuthorize("HR.Rank.Delete")]
        public async Task DeleteMultipleAsync(MultipleId input)
        {
            foreach (var item in input.Id)
            {
                var record = await _rank.FirstOrDefaultAsync(item);

                await _rank.DeleteAsync(record);
            }
        }

        [AbpAuthorize("HR.Rank.Read")]
        protected override async Task<Rank> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
