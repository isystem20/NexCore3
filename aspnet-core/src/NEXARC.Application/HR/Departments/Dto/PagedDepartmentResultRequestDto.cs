using NEXARC.Domain.Enumerations;
using Abp.Application.Services.Dto;

namespace NEXARC.NexDepartment.Dto
{
	public class PagedDepartmentResultRequestDto : PagedResultRequestDto
	{

		public string Keyword { get; set; }
		public RecordStatus? Status { get; set; }

	}
}
