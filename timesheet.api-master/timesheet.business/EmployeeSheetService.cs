using System;
using System.Linq;
using timesheet.api.model;
using timesheet.business.Interface;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
   
    public class EmployeeSheetService : IEmployeeSheetService
    {
        public TimesheetDb db { get; }
        public EmployeeSheetService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<EmployeeTimeSheet> GetTimeSheets(int id)
        {
            return this.db.EmployeeTimeSheets.Where(t => t.EmployeeId == id);
        }

        public bool SaveSheet(NewSheetView model)
        {
            if (model != null)
            {
                this.db.EmployeeTimeSheets.Add(new EmployeeTimeSheet()
                {
                    EmployeeId = model.EmployeeId,
                    TaskId = model.TaskId,
                    WorkingDate = model.WorkingDate,
                    WorkingHours = model.WorkingHours
                });
                this.db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
