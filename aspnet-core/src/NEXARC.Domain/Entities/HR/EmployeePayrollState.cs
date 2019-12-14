using NEXARC.Domain.Common;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Entities.Payroll;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXARC.Domain.Entities.HumanResource
{
    public class EmployeePayrollState : AuditableEntity
    {
        //public ChangeStateType ChangeType { get; set; } //Double check on EmployeeStateChangeType worked by Ollea
        public string Description { get; set; }
        public DateTime EffectivityDate { get; set; }

        //Use in Payroll
        public decimal MonthlyRate { get; set; }
        public decimal DailyRate { get; set; }
        public decimal HourlyRate { get; set; }

        public decimal MonthlyAllowance { get; set; }
        public decimal DailyAllowance { get; set; }
        public decimal HourlyAllowance { get; set; }

        //Check if employee is subject for computation of contrib
        public bool IsComputeSSS { get; set; }
        public bool IsComputePHIC { get; set; }
        public bool IsComputeHDMF { get; set; }
        public bool IsComputeWTAX { get; set; }


        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("RegionId")]
        public string RegionId { get; set; }
        public Region Regions { get; set; }

        [ForeignKey("PayGroupId")]
        public string PayGroupId { get; set; }
        public PayGroup PayGroups { get; set; }

        [ForeignKey("ParameterId")]
        public string ParameterId { get; set; } // need objects // multiplier of employee's rate, setup number of days in a year
        public Parameter Parameter { get; set; }

        [ForeignKey("PayrollPeriodId")]
        public string PayrollPeriodId { get; set; } // need objects // if employee's computation is daily, semi-monthly, hourly, monthly, every two weeks
        public PayrollPeriod PayrollPeriod { get; set; }

        [ForeignKey("PayrollFrequencyId")]
        public string PayrollFrequencyId { get; set; } // need objects//if his/her payroll is every 1st period, 2nd Period
        public PayrollFrequency PayrollFrequency { get; set; }

        [ForeignKey("TaxCodeId")]
        public string TaxCodeId { get; set; } //Need Tax Code clas e.g. S - Single, M - Married, M1
        public TaxCode TaxCode { get; set; }

        public RecordStatus Status { get; set; }
    }
}
