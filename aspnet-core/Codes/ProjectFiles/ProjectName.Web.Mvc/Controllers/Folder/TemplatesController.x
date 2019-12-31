using Abp.Application.Services.Dto;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using {{Project}}.Controllers;
using {{Project}}.Domain.Enumerations;
using {{Project}}.Nex{{EntityPlural}};
using {{Project}}.Nex{{EntityPlural}}.Dto;
using {{Project}}.Web.Helpers;
using {{Project}}.Web.Models.{{EntityPlural}};
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{Project}}.Web.Controllers.{{Folder}}
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
            var {{EntityLower}} = (await _{{EntityLower}}AppService.GetAllAsync(new Paged{{Entity}}ResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new {{Entity}}ListViewModel
            {
                {{EntityPlural}} = {{EntityLower}},
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

			@EnumToSelectList

            return View(model);
        }


        public async Task<ActionResult> Edit{{Entity}}Modal(int id)
        {

            var {{EntityLower}} = await _{{EntityLower}}AppService.GetAsync(new EntityDto<int>(id));
            var model = new Edit{{Entity}}ModalViewModel
            {
                {{Entity}} = {{EntityLower}},
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

			@EnumToSelectList

            return View("_Edit{{Entity}}Modal", model);


        }
    }
}
