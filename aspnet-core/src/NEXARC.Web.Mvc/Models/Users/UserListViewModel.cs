using System.Collections.Generic;
using NEXARC.Roles.Dto;
using NEXARC.Users.Dto;

namespace NEXARC.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
