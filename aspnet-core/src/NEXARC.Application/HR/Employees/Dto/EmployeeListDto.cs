using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using NEXARC.Domain.Common;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXARC.NexEmployee.Dto
{
    public class EmployeeListDto : AuditableDto
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
        public string BankAccountNo { get; set; }
        public string BankAccountId { get; set; } //no object yet, this is the bank that will be used of company for payout


    }
}
