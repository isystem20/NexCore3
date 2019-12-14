using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using NEXARC.Authorization;
using NEXARC.Domain.Entities.HR;
using NEXARC.NexEmployee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using NEXARC.Domain.Enumerations;
using Abp.Domain.Uow;
using NEXARC.HR.Employees.Dto;

namespace NEXARC.HR.Employees
{
    [AbpAuthorize(PermissionNames.Pages_Employees)]
    public class EmployeeAppService : AsyncCrudAppService<Employee, EmployeeDto, int, PagedEmployeeResultRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
    {
        private readonly IAbpSession _abpSession;

        private readonly IRepository<Employee> _employee;
        private readonly IRepository<EmployeeState> _employeeState;
        private readonly IRepository<Department> _department;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public EmployeeAppService(IUnitOfWorkManager unitOfWorkManager, IAbpSession abpSession, IRepository<Department> department, IRepository<Employee> employee, IRepository<EmployeeState> employeeState) : base(employee)
        {
            _employee = employee;
            _abpSession = abpSession;
            _employeeState = employeeState;
            _department = department;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [AbpAuthorize("HR.Employee.Read")]
        protected override IQueryable<Employee> CreateFilteredQuery(PagedEmployeeResultRequestDto input)
        {

            try
            {
                var result = Repository.GetAllIncluding(x => x.EmployeeStates)
                    .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.FirstName.Contains(input.Keyword))
                    .WhereIf(input.Status.HasValue, x => x.Status == input.Status);
                return result;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        protected override EmployeeDto MapToEntityDto(Employee emp)
        {
            var employeeState = _employeeState.GetAll()
                .Where(e => e.EffectivityDate <= DateTime.Now && e.EmployeeId == emp.Id)
                .OrderByDescending(o => o.EffectivityDate).SingleOrDefault();
            var empDto = base.MapToEntityDto(emp);
            //var currentState = ObjectMapper.Map<EmployeeStateDto>(employeeState);
            empDto.CurrentState = employeeState;
            return empDto;
        }

        [AbpAuthorize("HR.Employee.Create")]
        public override async Task<EmployeeDto> Create(CreateEmployeeDto input)
        {
            var entity = MapToEntity(input);

            var empId = await Repository.InsertAndGetIdAsync(entity);

            var empState = new EmployeeState
            {
                EffectivityDate = DateTime.Now.Date,
                EmployeeId = empId,
                DepartmentId = input.Department
            };

            await _employeeState.InsertAsync(empState);

            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);

        }

        [AbpAuthorize("HR.Employee.Update")]
        public override async Task<EmployeeDto> Update(UpdateEmployeeDto input)
        {
            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        [AbpAuthorize("HR.Employee.Delete")]
        public override async Task Delete(EntityDto<int> input)
        {
            var record = await _employee.FirstOrDefaultAsync(input.Id);

            await _employee.DeleteAsync(record);
        }

        [AbpAuthorize("HR.Employee.Read")]
        protected override async Task<Employee> GetEntityByIdAsync(int id)
        {
            try
            {
                //return Repository.GetAllIncluding(x => x.EmployeeStates.Select(s => s.Status == RecordStatus.ACTIVE)).Single();
                return await Repository.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
            //Need to check this

        }

    }
}
