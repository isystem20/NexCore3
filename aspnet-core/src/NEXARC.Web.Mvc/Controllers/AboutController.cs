using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using NEXARC.Controllers;

namespace NEXARC.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : NEXARCControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
