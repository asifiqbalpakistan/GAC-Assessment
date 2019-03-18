using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    public class EmployeeTimeSheet
    {
        [Key]
        public int EmployeeTimeSheetId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
        public DateTime WorkingDate { get; set; }
        public int WorkingHours { get; set; }
    }
}