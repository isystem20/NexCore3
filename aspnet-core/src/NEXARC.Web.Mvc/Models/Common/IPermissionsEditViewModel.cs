using System.Collections.Generic;
using NEXARC.Roles.Dto;

namespace NEXARC.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}