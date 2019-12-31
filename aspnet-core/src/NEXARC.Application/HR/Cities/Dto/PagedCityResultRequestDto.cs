using NEXARC.Domain.Enumerations;
using NEXARC.Domain.Entities.HumanResource;
using Abp.Application.Services.Dto;

namespace NEXARC.NexCities.Dto
{
	public class PagedCityResultRequestDto : PagedResultRequestDto
	{

		public string Keyword { get; set; }
		public RecordStatus? Status { get; set; }

	}
}
