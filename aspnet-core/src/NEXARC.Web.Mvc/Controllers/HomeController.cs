using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using NEXARC.Controllers;

namespace NEXARC.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : NEXARCControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
