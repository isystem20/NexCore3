using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Entities.Payroll;
using NEXARC.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NEXARC.Domain.Entities.HumanResource
{
    //This is the default schedule of employee
    public class EmployeeScheduleState
    {
        public WeekDay WeekDay { get; set; }
        
        [ForeignKey("ShiftScheduleId")]
        public int ShiftScheduleId { get; set; }
        public ShiftSchedule ShiftSchedule { get; set; }

        [ForeignKey("DayTypeId")]
        public int DayTypeId { get; set; }
        public DayType DayType { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
