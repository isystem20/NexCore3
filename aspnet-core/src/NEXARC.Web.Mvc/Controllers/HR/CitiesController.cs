using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
using NEXARC.Domain.Enumerations;
using NEXARC.HR.Departments;
using NEXARC.NexCities;
using NEXARC.NexCities.Dto;
using NEXARC.NexDepartment.Dto;
using NEXARC.Web.Helpers;
using NEXARC.Web.Models.Cities;
using NEXARC.Web.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.HR
{
    public class CitiesController : NEXARCControllerBase
    {
        private readonly ICityAppService _cityAppService;
        private readonly PairedItemListing _pairedItemListing;

        public CitiesController(
            ICityAppService cityAppService,
            PairedItemListing pairedItemListing)
        {
            _cityAppService = cityAppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var notice = (await _cityAppService.GetAllAsync(new PagedCityResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new CityListViewModel
            {
                Cities = notice,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View(model);
        }


        public async Task<ActionResult> EditCityModal(int id)
        {

            var notice = await _cityAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditCityModalViewModel
            {
                City = notice,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View("_EditCityModal", model);


        }
    }
}
