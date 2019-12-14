using NEXARC.Domain.Common;
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

        [ForeignKey("BarangayId")]
        public int BarangayId { get; set; }
        public Barangay Barangay { get; set; }

        [ForeignKey("MunicipalityId")]
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }

        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("ProvinceId")]
        public int ProvinceId { get; set; }
        public int Province { get; set; }

        [ForeignKey("RegionId")]
        public int RegionId { get; set; }
        public Region Region { get; set; }

        public RecordStatus Status { get; set; }
        
    }
}
