using System;
using System.Linq;
using timesheet.business.Interface;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
   
    public class EmployeeService:IEmployeeService
    {
        public TimesheetDb db { get; }
        public EmployeeService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return this.db.Employees;
        }
    }
}
