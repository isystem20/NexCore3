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
    public class EmployeeWorkHistory : AuditableEntity
    {
        public string EmployerName { get; set; }
        public string EmployerAddress { get; set; }
        public string ZipCode { get; set; }
        public string Designation { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Year { get; set; }

        //The following is required to be used in payroll computation
        public decimal GrossTaxableCompensationIncome_25 { get; set; }
        public decimal _13thMonthPayAndOtherBenefits_37 { get; set; }
        public decimal ContributionsAndUnionDues_39 { get; set; }
        public decimal SalariesAndCompensation_40 { get; set; }
        public decimal Taxable13thMonthPayAndOtherBenefits_51 { get; set; }
        public decimal PremiumPaid_27 { get; set; }
        public decimal TotalTaxWithheld_31 { get; set; }
        public decimal DeMinimisBenefits_38 { get; set; }
        public RecordStatus Status { get; set; }
        
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
