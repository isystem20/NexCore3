using NEXARC.NexDepartment.Dto;
using System.Collections.Generic;

namespace NEXARC.Web.Models.Departments
{
    public class DepartmentListViewModel
    {
        public IReadOnlyList<DepartmentDto> Departments { get; set; }

    }
}
