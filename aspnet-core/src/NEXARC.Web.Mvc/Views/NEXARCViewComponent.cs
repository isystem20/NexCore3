using Abp.AspNetCore.Mvc.ViewComponents;

namespace NEXARC.Web.Views
{
    public abstract class NEXARCViewComponent : AbpViewComponent
    {
        protected NEXARCViewComponent()
        {
            LocalizationSourceName = NEXARCConsts.LocalizationSourceName;
        }
    }
}
