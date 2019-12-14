using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace NEXARC.Web.Views
{
    public abstract class NEXARCRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected NEXARCRazorPage()
        {
            LocalizationSourceName = NEXARCConsts.LocalizationSourceName;
        }
    }
}
