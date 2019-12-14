using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NEXARC.Web.Views.Shared.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : NEXARCViewComponent
    {
        public ControlSidebarViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ControlSidebarViewModel();
            return View(model);
        }
    }
}
