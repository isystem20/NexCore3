using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
using NEXARC.Domain.Enumerations;
using NEXARC.NexRanks;
using NEXARC.NexRanks.Dto;
using NEXARC.Web.Helpers;
using NEXARC.Web.Models.Ranks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.HR
{
    public class RanksController : NEXARCControllerBase
    {
        private readonly IRankAppService _rankAppService;
        private readonly PairedItemListing _pairedItemListing;

        public RanksController(
            IRankAppService rankAppService,
            PairedItemListing pairedItemListing)
        {
            _rankAppService = rankAppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var rank = (await _rankAppService.GetAllAsync(new PagedRankResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new RankListViewModel
            {
                Ranks = rank,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View(model);
        }


        public async Task<ActionResult> EditRankModal(int id)
        {

            var rank = await _rankAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditRankModalViewModel
            {
                Rank = rank,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View("_EditRankModal", model);


        }
    }
}
