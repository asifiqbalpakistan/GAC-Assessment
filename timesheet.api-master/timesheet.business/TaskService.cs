using System;
using System.Linq;
using timesheet.business.Interface;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    
    public class TaskService : ITaskService
    {
        public TimesheetDb db { get; }
        public TaskService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Task> GetTasks()
        {
            return this.db.Tasks;
        }
    }
}
