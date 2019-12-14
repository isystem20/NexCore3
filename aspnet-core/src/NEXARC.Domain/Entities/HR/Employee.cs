
using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HumanResource;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXARC.Domain.Entities.HR
{
    public class Employee : AuditableEntity
    {
        public Employee()
        {
            //UserAccounts = new HashSet<ApplicationUser>();
            EmployeeStates = new HashSet<EmployeeState>();
            //EmployeePayrollStates = new HashSet<EmployeePayrollState>();
            //EmployeeScheduleStates = new HashSet<EmployeeScheduleState>();

            //EmployeeCertificates = new HashSet<EmployeeCertificate>();
            //EmployeeAttachments = new HashSet<EmployeeAttachment>();
            //EmployeeWorkHistories = new HashSet<EmployeeWorkHistory>();

            //EmployeeOffenseAndViolations = new HashSet<EmployeeOffenseAndViolation>();
        }

        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
       
        public string FullName { get; set; } //. e.g. Juan D. Cruz
        public string FormalName { get; set; } // e.g. Cruz, Juan D.
        
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        
        public string TIN { get; set; }
        public string HDMF { get; set; }
        public string PHIC { get; set; }
        public string SSS { get; set; }
        public string AddressStreet { get; set; }
        
        public RecordStatus Status { get; set; }
        public Gender Gender { get; set; }
        public Suffix Suffix { get; set; } // need enum e.g. I, II, III, Sr. Jr.

        //This is confidential and CRITICAL, if possible integrate encryptions
        public string BankAccountNo { get; set; }
        public BankAccountType BankAccountType { get; set; } //CA / SA      
        public string BankAccountId { get; set; } //no object yet, this is the bank that will be used of company for payout  

        public CivilStatus CivilStatus { get; set; }
        public DateTime? HiredDate { get; set; }
                     


        public int NationalityId { get; set; }
        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public int RegionId { get; set; }

        public ICollection<EmployeeState> EmployeeStates { get; set; }
        
        //public ICollection<ApplicationUser> UserAccounts { get; private set; }
        //public List<EmployeePayrollState> EmployeePayrollStates { get; set; }
        //public List<EmployeeScheduleState> EmployeeScheduleStates { get; set; }
        //public List<EmployeeCertificate> EmployeeCertificates { get; set; }
        //public List<EmployeeAttachment> EmployeeAttachments { get; set; }
        //public List<EmployeeWorkHistory> EmployeeWorkHistories { get; set; }
        //public List<EmployeeOffenseAndViolation> EmployeeOffenseAndViolations { get; set; }
        //public List<EmployeeEarning> EmployeeEarning { get; set; }

        //Need to add the following
        //Employee Dependents
        //EmployeeEducationalAttainment
        //EmployeeDisciplinaryActions
        //EmployeeOffenseAndViolation
    }
}
