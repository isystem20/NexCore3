using NEXARC.Domain.Enumerations;
using Abp.Application.Services.Dto;

namespace NEXARC.NexEmployee.Dto
{
	public class PagedEmployeeResultRequestDto : PagedResultRequestDto
	{

		public string Keyword { get; set; }
		public RecordStatus? Status { get; set; }

	}
}
