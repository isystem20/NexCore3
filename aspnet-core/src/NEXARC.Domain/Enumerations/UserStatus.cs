using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Enumerations
{
    public enum UserStatus
    {
        [Description("success")]
        ACTIVE = 200, //Accessible and visible to all permitted users
        [Description("secondary")]
        INACTIVE = 400, //
        [Description("warning")]
        TRASHED = 404,
        [Description("danger")]
        LOCKED = 423,
        [Description("secondary")]
        DEPROVISIONED = 401,
        [Description("info")]
        ARCHIVED = 428,
    }
}
