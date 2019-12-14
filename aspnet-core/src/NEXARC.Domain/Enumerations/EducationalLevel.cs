using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Enumerations
{
    public enum EducationalLevel
    {
        [Description("Bachelor of Science")]
        BachelorOfScience = 1,
        [Description("Bachelor of Arts")]
        BachelorOfArt = 2,
        [Description("Bachelor of Arts")]
        Doctorate = 3,
        [Description("High School")]
        HighSchool = 4,


    }
}
