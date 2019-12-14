using NEXARC.Domain.Enumerations;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using NEXARC.Domain.Entities.HR;

namespace NEXARC.NexEmployee.Dto
{
	[AutoMapTo(typeof(Employee))]
	public class CreateEmployeeDto
	{

        [Required]
        public string Code { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
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
        public string BankAccountNo { get; set; }
        public string BankAccountId { get; set; } //no object yet, this is the bank that will be used of company for payout
        public UserStatus Status { get; set; }


        //Employee State
        public string Description { get; set; }
        public DateTime EffectivityDate { get; set; }

        public DateTime? HiredDate { get; set; }
        public DateTime? RegularDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }


        //USE IN HR
        //[Required]
        public int Company { get; set; }
        public int Site { get; set; }
        public int Employee { get; set; }
        public int Division { get; set; }
        public int Department { get; set; }
        public int Section { get; set; }
        public int CostCenter { get; set; }
        public int Position { get; set; }
        public int EmploymentType { get; set; }
        public int Rank { get; set; }
        public int Group { get; set; }
        public RecordStatus StateStatus { get; set; } //Double Check

    }
}
