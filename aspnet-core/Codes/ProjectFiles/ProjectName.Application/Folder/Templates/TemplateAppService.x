using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using {{Project}}.Authorization;
@AllNS
using {{Project}}.Nex{{EntityPlural}}.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;

namespace {{Project}}.Nex{{EntityPlural}}
{
    [AbpAuthorize(PermissionNames.Pages_{{EntityPlural}})]
    public class {{Entity}}AppService : AsyncCrudAppService<{{Entity}}, {{Entity}}Dto, int, Paged{{Entity}}ResultRequestDto, Create{{Entity}}Dto, Update{{Entity}}Dto>, I{{Entity}}AppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<{{Entity}}> _{{EntityLower}};

        public {{Entity}}AppService(IAbpSession abpSession, IRepository<{{Entity}}> {{EntityLower}}) : base({{EntityLower}})
        {
            _{{EntityLower}} = {{EntityLower}};
            _abpSession = abpSession;
        }

        [AbpAuthorize("{{Entity}}.Read")]
        protected override IQueryable<{{Entity}}> CreateFilteredQuery(Paged{{Entity}}ResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("{{Entity}}.Create")]
        public override async Task<{{Entity}}Dto> Create(Create{{Entity}}Dto input)
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

        [AbpAuthorize("{{Entity}}.Update")]
        public override async Task<{{Entity}}Dto> Update(Update{{Entity}}Dto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("{{Entity}}.Delete")]
        public override async Task Delete(EntityDto<int> input)
        {
            var record = await _{{EntityLower}}.FirstOrDefaultAsync(input.Id);

            await _{{EntityLower}}.DeleteAsync(record);
        }

        [AbpAuthorize("{{Entity}}.Read")]
        protected override async Task<{{Entity}}> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
