using Abp.Application.Services;
using NEXARC.NexDepartment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.HR.Departments
{
    public interface IDepartmentAppService : IAsyncCrudAppService<DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, UpdateDepartmentDto>
    {

        //Put something if applicable

    }
}
