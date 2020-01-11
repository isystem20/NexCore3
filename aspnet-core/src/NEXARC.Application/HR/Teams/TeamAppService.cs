using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using NEXARC.Authorization;
using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.NexTeams.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using NEXARC.Common.Dto;

namespace NEXARC.NexTeams
{
    [AbpAuthorize("HR.Team")]
    public class TeamAppService : AsyncCrudAppService<Team, TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, UpdateTeamDto>, ITeamAppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<Team> _team;

        public TeamAppService(IAbpSession abpSession, IRepository<Team> team) : base(team)
        {
            _team = team;
            _abpSession = abpSession;
        }

        [AbpAuthorize("HR.Team.Read")]
        protected override IQueryable<Team> CreateFilteredQuery(PagedTeamResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("HR.Team.Create")]
        public override async Task<TeamDto> CreateAsync(CreateTeamDto input)
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

        [AbpAuthorize("HR.Team.Update")]
        public override async Task<TeamDto> UpdateAsync(UpdateTeamDto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("HR.Team.Delete")]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var record = await _team.FirstOrDefaultAsync(input.Id);

            await _team.DeleteAsync(record);
        }


		[AbpAuthorize("HR.Team.Delete")]
        public async Task DeleteMultipleAsync(MultipleId input)
        {
            foreach (var item in input.Id)
            {
                var record = await _team.FirstOrDefaultAsync(item);

                await _team.DeleteAsync(record);
            }
        }

        [AbpAuthorize("HR.Team.Read")]
        protected override async Task<Team> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
