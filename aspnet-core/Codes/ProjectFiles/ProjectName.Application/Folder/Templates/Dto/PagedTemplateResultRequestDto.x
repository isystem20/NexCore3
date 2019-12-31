@AllNS
using Abp.Application.Services.Dto;

namespace {{Project}}.Nex{{EntityPlural}}.Dto
{
	public class Paged{{Entity}}ResultRequestDto : PagedResultRequestDto
	{

		public string Keyword { get; set; }
		public RecordStatus? Status { get; set; }

	}
}
