using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.api.model;
using timesheet.model;

namespace timesheet.business.Interface
{
    public interface IEmployeeSheetService
    {
        IQueryable<EmployeeTimeSheet> GetTimeSheets(int id);
        bool SaveSheet(NewSheetView model);
    }
}
