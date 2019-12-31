using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using Abp.Application.Services.Dto;

namespace NEXARC.NexRanks.Dto
{
	public class PagedRankResultRequestDto : PagedResultRequestDto
	{

		public string Keyword { get; set; }
		public RecordStatus? Status { get; set; }

	}
}
