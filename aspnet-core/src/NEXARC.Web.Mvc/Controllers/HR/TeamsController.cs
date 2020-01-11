using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
using NEXARC.Domain.Enumerations;
using NEXARC.NexTeams;
using NEXARC.NexTeams.Dto;
using NEXARC.Web.Helpers;
using NEXARC.Web.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.HR
{
    public class TeamsController : NEXARCControllerBase
    {
        private readonly ITeamAppService _teamAppService;
        private readonly PairedItemListing _pairedItemListing;

        public TeamsController(
            ITeamAppService teamAppService,
            PairedItemListing pairedItemListing)
        {
            _teamAppService = teamAppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var team = (await _teamAppService.GetAllAsync(new PagedTeamResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new TeamListViewModel
            {
                Teams = team,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View(model);
        }


        public async Task<ActionResult> EditTeamModal(int id)
        {

            var team = await _teamAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditTeamModalViewModel
            {
                Team = team,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View("_EditTeamModal", model);


        }
    }
}
