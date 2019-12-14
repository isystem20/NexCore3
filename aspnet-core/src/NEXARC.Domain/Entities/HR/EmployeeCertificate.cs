using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeeCertificate: AuditableEntity
    {
        public string CertificateCustomName { get; set; }
        public string IssuedInstitution { get; set; }
        public string IssuedDate { get; set; }
        public string ValidityExpiration { get; set; }
        public string Remarks { get; set; }

        [ForeignKey("CertificateId")]
        public string CertificateId { get; set; }
        public Certificate Certificates { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
