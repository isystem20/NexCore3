using Abp.Dependency;
using Abp.UI;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Web.Helpers
{
    public class PairedItemListing : ITransientDependency
    {

        public List<SelectListItem> EnumToSelectList<T>(T enumClass) where T : new()
        {
            try
            {
                var enumlist = new List<SelectListItem>();
                foreach (T eVal in Enum.GetValues(typeof(T)))
                {
                    enumlist.Add(new SelectListItem { Text = Enum.GetName(typeof(T), eVal), Value = eVal.ToString() });
                }
                return enumlist;
            }
            catch (Exception e)
            {

                throw new UserFriendlyException(e.Message);
            }
        }
    }
}
