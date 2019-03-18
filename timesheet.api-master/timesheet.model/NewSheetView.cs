using System;
using System.Collections.Generic;
using System.Text;

namespace timesheet.api.model
{
    public class NewSheetView
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int WorkingHours { get; set; }
        public DateTime WorkingDate { get; set; }
    }
}