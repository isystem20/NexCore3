using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using NEXARC.Authorization;
using NEXARC.Domain.Entities.HR;
using NEXARC.NexDepartment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;

namespace NEXARC.HR.Departments
{
    [AbpAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, UpdateDepartmentDto>, IDepartmentAppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<Department> _department;

        public DepartmentAppService(IAbpSession abpSession, IRepository<Department> department) : base(department)
        {
            _department = department;
            _abpSession = abpSession;
        }

        [AbpAuthorize("HR.Department.Read")]
        protected override IQueryable<Department> CreateFilteredQuery(PagedDepartmentResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword))
                .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
        }

        [AbpAuthorize("HR.Department.Create")]
        public override async Task<DepartmentDto> Create(CreateDepartmentDto input)
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

        [AbpAuthorize("HR.Department.Update")]
        public override async Task<DepartmentDto> Update(UpdateDepartmentDto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("HR.Department.Delete")]
        public override async Task Delete(EntityDto<int> input)
        {
            var record = await _department.FirstOrDefaultAsync(input.Id);

            await _department.DeleteAsync(record);
        }

        [AbpAuthorize("HR.Department.Read")]
        protected override async Task<Department> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

    }
}
