using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
using NEXARC.Domain.Enumerations;
using NEXARC.NexDivisions;
using NEXARC.NexDivisions.Dto;
using NEXARC.Web.Helpers;
using NEXARC.Web.Models.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.HR
{
    public class DivisionsController : NEXARCControllerBase
    {
        private readonly IDivisionAppService _divisionAppService;
        private readonly PairedItemListing _pairedItemListing;

        public DivisionsController(
            IDivisionAppService divisionAppService,
            PairedItemListing pairedItemListing)
        {
            _divisionAppService = divisionAppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var division = (await _divisionAppService.GetAllAsync(new PagedDivisionResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new DivisionListViewModel
            {
                Divisions = division,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View(model);
        }


        public async Task<ActionResult> EditDivisionModal(int id)
        {

            var division = await _divisionAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditDivisionModalViewModel
            {
                Division = division,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View("_EditDivisionModal", model);


        }
    }
}
