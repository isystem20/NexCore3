using Abp.Application.Services;
using NEXARC.NexEmployee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.HR.Employees
{
    public interface IEmployeeAppService : IAsyncCrudAppService<EmployeeDto, int, PagedEmployeeResultRequestDto, CreateEmployeeDto, UpdateEmployeeDto>
    {

        //Put something if applicable

    }
}
