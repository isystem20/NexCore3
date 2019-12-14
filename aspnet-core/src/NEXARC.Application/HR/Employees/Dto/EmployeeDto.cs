using NEXARC.Domain.Enumerations;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using System;
using NEXARC.Domain.Entities.HR;
using System.Collections.Generic;

namespace NEXARC.NexEmployee.Dto
{
	[AutoMapFrom(typeof(Employee))]
	public class EmployeeDto : EntityDto<int>
	{

        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string FullName { get; set; } //. e.g. Juan D. Cruz
        public string FormalName { get; set; } // e.g. Cruz, Juan D.

        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? HiredDate { get; set; }

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
        public int Nationality { get; set; }
        public int Company { get; set; }
        public int Barangay { get; set; }
        public int Municipality { get; set; }
        public int City { get; set; }
        public int Province { get; set; }
        public int Region { get; set; }

        public EmployeeState CurrentState { get; set; }

    }
}
