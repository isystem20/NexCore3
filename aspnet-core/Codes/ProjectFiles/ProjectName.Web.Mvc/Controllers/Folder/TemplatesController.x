using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
using NEXARC.Domain.Enumerations;
using NEXARC.HR.Departments;
using NEXARC.NexDepartment.Dto;
using NEXARC.Web.Helpers;
using NEXARC.Web.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.{{Folder}}
{
    public class {{EntityPlural}}Controller : NEXARCControllerBase
    {
        private readonly I{{Entity}}AppService _{{EntityLower}}AppService;
        private readonly PairedItemListing _pairedItemListing;

        public {{EntityPlural}}Controller(
            I{{Entity}}AppService {{EntityLower}}AppService,
            PairedItemListing pairedItemListing)
        {
            _{{EntityLower}}AppService = {{EntityLower}}AppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var notice = (await _{{EntityLower}}AppService.GetAllAsync(new Paged{{Entity}}ResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new {{Entity}}ListViewModel
            {
                Departments = notice,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

			@EnumToSelectList

            return View(model);
        }


        public async Task<ActionResult> Edit{{Entity}}Modal(int id)
        {

            var notice = await _{{EntityLower}}AppService.GetAsync(new EntityDto<int>(id));
            var model = new Edit{{Entity}}ModalViewModel
            {
                {{Entity}} = notice,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

			@EnumToSelectList

            return View("_Edit{{Entity}}Modal", model);


        }
    }
}
