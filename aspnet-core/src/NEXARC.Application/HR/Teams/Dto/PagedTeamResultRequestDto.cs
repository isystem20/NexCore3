using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using Abp.Application.Services.Dto;

namespace NEXARC.NexTeams.Dto
{
	public class PagedTeamResultRequestDto : PagedResultRequestDto
	{

		public string Keyword { get; set; }
		public RecordStatus? Status { get; set; }

	}
}
