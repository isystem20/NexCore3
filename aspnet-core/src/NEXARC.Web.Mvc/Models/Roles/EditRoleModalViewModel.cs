using Abp.AutoMapper;
using NEXARC.Roles.Dto;
using NEXARC.Web.Models.Common;

namespace NEXARC.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
