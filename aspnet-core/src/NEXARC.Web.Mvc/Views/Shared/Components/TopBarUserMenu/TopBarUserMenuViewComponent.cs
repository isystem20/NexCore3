using Microsoft.AspNetCore.Mvc;
using Abp.Configuration.Startup;
using System.Threading.Tasks;
using NEXARC.Sessions;

namespace NEXARC.Web.Views.Shared.Components.TopBarUserMenu
{
    public class TopBarUserMenuViewComponent : NEXARCViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public TopBarUserMenuViewComponent(ISessionAppService sessionAppService, 
            IMultiTenancyConfig multiTenancyConfig)
        {
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new TopBarUserMenuViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
            };

            return View(model);
        }
    }
}
