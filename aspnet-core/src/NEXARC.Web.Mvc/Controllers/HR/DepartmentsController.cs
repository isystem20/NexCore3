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

namespace NEXARC.Web.Controllers.HR
{
    public class DepartmentsController : NEXARCControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;
        private readonly PairedItemListing _pairedItemListing;

        public DepartmentsController(
            IDepartmentAppService departmentAppService,
            PairedItemListing pairedItemListing)
        {
            _departmentAppService = departmentAppService;
            _pairedItemListing = pairedItemListing;
        }

        public async Task<ActionResult> Index()
        {
            var notice = (await _departmentAppService.GetAll(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new DepartmentListViewModel
            {
                Departments = notice,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View(model);
        }


        public async Task<ActionResult> EditDepartmentModal(int id)
        {

            var notice = await _departmentAppService.Get(new EntityDto<int>(id));
            var model = new EditDepartmentModalViewModel
            {
                Department = notice,
            };

            ViewBag.Status = _pairedItemListing.EnumToSelectList(new RecordStatus());

            return View("_EditDepartmentModal", model);


        }
    }
}
