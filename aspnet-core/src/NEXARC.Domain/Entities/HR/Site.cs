using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class Site : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddressStreet { get; set; }


        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public int RegionId { get; set; }

        public RecordStatus Status { get; set; }
        
    }
}
