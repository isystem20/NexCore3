using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
using NEXARC.Domain.Enumerations;
using NEXARC.NexPositions;
using NEXARC.NexPositions.Dto;
using NEXARC.Web.Helpers;
using NEXARC.Web.Models.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.HR
{
    public class PositionsController : NEXARCControllerBase
    {
        private readonly IPositionAppService _positionAppService;
        private readonly PairedItemListing _pairedItemListing;

        public PositionsController(
            IPositionAppService positionAppService,
            PairedItemListing pairedItemListing)
        {
            _positionAppService = positionAppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var position = (await _positionAppService.GetAllAsync(new PagedPositionResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new PositionListViewModel
            {
                Positions = position,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View(model);
        }


        public async Task<ActionResult> EditPositionModal(int id)
        {

            var position = await _positionAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditPositionModalViewModel
            {
                Position = position,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View("_EditPositionModal", model);


        }
    }
}
