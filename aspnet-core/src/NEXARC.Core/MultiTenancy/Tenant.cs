using Abp.MultiTenancy;
using NEXARC.Authorization.Users;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.Domain.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXARC.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }

        public string Code { get; set; }
        public string RegiseteredName { get; set; }
        public string RegisteredAddress { get; set; }
        public string ContactPersons { get; set; }
        public byte Logo { get; set; }
        public string Email { get; set; }

        public string MobileNo { get; set; }
        public string TelNo { get; set; }
        public string WebSites { get; set; }

        public string TIN { get; set; }
        public string PHIC { get; set; }
        public string HDMF { get; set; }
        public string SSS { get; set; }

        public RecordStatus Status { get; set; }

        public int IndustryId { get; set; }
        public string Description { get; set; }

        public int NationalityId { get; set; }
        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public int Province { get; set; }
        public int RegionId { get; set; }

    }
}
