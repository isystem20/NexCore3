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
using NEXARC.Common.Dto;

namespace {{Project}}.Nex{{EntityPlural}}
{
    [AbpAuthorize("{{Permission}}.{{Entity}}")]
    public class {{Entity}}AppService : AsyncCrudAppService<{{Entity}}, {{Entity}}Dto, int, Paged{{Entity}}ResultRequestDto, Create{{Entity}}Dto, Update{{Entity}}Dto>, I{{Entity}}AppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<{{Entity}}> _{{EntityLower}};

        public {{Entity}}AppService(IAbpSession abpSession, IRepository<{{Entity}}> {{EntityLower}}) : base({{EntityLower}})
        {
            _{{EntityLower}} = {{EntityLower}};
            _abpSession = abpSession;
        }

        [AbpAuthorize("{{Permission}}.{{Entity}}.Read")]
        protected override IQueryable<{{Entity}}> CreateFilteredQuery(Paged{{Entity}}ResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("{{Permission}}.{{Entity}}.Create")]
        public override async Task<{{Entity}}Dto> CreateAsync(Create{{Entity}}Dto input)
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

        [AbpAuthorize("{{Permission}}.{{Entity}}.Update")]
        public override async Task<{{Entity}}Dto> UpdateAsync(Update{{Entity}}Dto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("{{Permission}}.{{Entity}}.Delete")]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var record = await _{{EntityLower}}.FirstOrDefaultAsync(input.Id);

            await _{{EntityLower}}.DeleteAsync(record);
        }


		[AbpAuthorize("{{Permission}}.{{Entity}}.Delete")]
        public async Task DeleteMultipleAsync(MultipleId input)
        {
            foreach (var item in input.Id)
            {
                var record = await _{{EntityLower}}.FirstOrDefaultAsync(item);

                await _{{EntityLower}}.DeleteAsync(record);
            }
        }

        [AbpAuthorize("{{Permission}}.{{Entity}}.Read")]
        protected override async Task<{{Entity}}> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
