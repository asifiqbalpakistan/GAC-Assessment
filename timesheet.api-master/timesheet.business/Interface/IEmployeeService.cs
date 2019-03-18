using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.model;

namespace timesheet.business.Interface
{
    public interface IEmployeeService { IQueryable<Employee> GetEmployees(); }
}
