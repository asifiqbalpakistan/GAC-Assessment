using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using timesheet.model;

namespace timesheet.api.model
{
    public class EmployeeView : Employee
    {
        public int WeeklyTotal { get; set; }
        public int WeeklyAvrage { get; set; }
    }
}