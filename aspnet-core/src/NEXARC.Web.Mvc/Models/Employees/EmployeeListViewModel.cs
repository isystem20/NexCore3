using NEXARC.NexEmployee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEXARC.Web.Models.Employees
{
    public class EmployeeListViewModel
    {
        public IReadOnlyList<EmployeeDto> Employees { get; set; }

        public List<string> Columns { get; set; }
    }
}
