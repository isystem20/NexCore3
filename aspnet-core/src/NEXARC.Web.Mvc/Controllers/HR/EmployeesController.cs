using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NEXARC.Controllers;
//using NEXARC.Domain.Enumerations;
using NEXARC.HR.Departments;
using NEXARC.HR.Employees;
using NEXARC.NexDepartment.Dto;
using NEXARC.NexEmployee.Dto;
using NEXARC.Web.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NEXARC.Web.Controllers.HR
{
    public class EmployeesController: NEXARCControllerBase
    {

        private readonly IEmployeeAppService _employeeAppService;
        private readonly IDepartmentAppService _departmentAppService;

        public EmployeesController(IEmployeeAppService userAppService,
            IDepartmentAppService departmentAppService)
        {
            _employeeAppService = userAppService;
            _departmentAppService = departmentAppService;
        }

        public async Task<ActionResult> Index()
        {
            var employees = (await _employeeAppService.GetAll(new PagedEmployeeResultRequestDto { MaxResultCount = int.MaxValue })).Items; // Paging not implemented yet
            var model = new EmployeeListViewModel
            {
                Employees = employees,
            };

            //need to create a function for this lookup
            var gender = new List<SelectListItem>();
            foreach (Gender eVal in Enum.GetValues(typeof(Gender)))
            {
                gender.Add(new SelectListItem { Text = Enum.GetName(typeof(Gender), eVal), Value = eVal.ToString() });
            }
            ViewBag.Gender = gender;

            var status = new List<SelectListItem>();
            foreach (RecordStatus eVal in Enum.GetValues(typeof(RecordStatus)))
            {
                status.Add(new SelectListItem { Text = Enum.GetName(typeof(RecordStatus), eVal), Value = eVal.ToString() });
            }
            ViewBag.Status = status;

            //IDictionary<int, string> departmentNames = new Dictionary<int, string>();
            var departments = (await _departmentAppService.GetAll(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            //foreach (var item in departments)
            //{
            //    departmentNames.Add(item.Id,item.Name);
            //}
            //ViewBag.Departments = departmentNames;


            var departmentNames = new List<SelectListItem>();
            foreach (var item in departments)
            {
                departmentNames.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Departments = departmentNames;

            return View(model);
        }

        //private async IDictionary<int, string> GetIdAndName<T>(T TInterface, object TClass) where T : new ()
        //{
        //    IDictionary<int, string> list = new Dictionary<int, string>();

        //    if (TInterface.GetType().GetMethod("GetAll") != null && TClass.GetProperty("MaxResultCount") != null)
        //    {
                
        //        MethodInfo method = typeof(T).GetMethod("GetAll");
        //        MethodInfo generic = method.MakeGenericMethod(TClass);
        //        var datalist = (await generic.Invoke(this, TClass { MaxResultCount = int.MaxValue })).Items;



        //        var datalist = (await newInterface.GetAll(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue })).Items;
        //        foreach (var item in datalist)
        //        {
        //            list.Add(item.Id, item.Name);
        //        }
        //        return list;
        //    }



        //}



        public async Task<ActionResult> EditEmployeeModal(int id)
        {

            var data = await _employeeAppService.Get(new EntityDto<int>(id));
            var model = new EditEmployeeModalViewModel
            {
                Employee = data,
            };

            var gender = new List<SelectListItem>();
            foreach (Gender eVal in Enum.GetValues(typeof(Gender)))
            {
                gender.Add(new SelectListItem { Text = Enum.GetName(typeof(Gender), eVal), Value = eVal.ToString() });
            }
            ViewBag.Gender = gender;

            var status = new List<SelectListItem>();
            foreach (RecordStatus eVal in Enum.GetValues(typeof(RecordStatus)))
            {
                status.Add(new SelectListItem { Text = Enum.GetName(typeof(RecordStatus), eVal), Value = eVal.ToString() });
            }
            ViewBag.Status = status;

            return View("_EditEmployeeModal", model);


        }


    }
}
