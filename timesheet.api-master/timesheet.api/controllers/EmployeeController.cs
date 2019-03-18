using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timesheet.api.model;
using timesheet.business;
using timesheet.business.Interface;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeSheetService employeeSheetService;
        private readonly ITaskService taskService;
        public EmployeeController(IEmployeeService employeeService, IEmployeeSheetService employeeSheetService, ITaskService taskService)
        {
            this.employeeService = employeeService;
            this.employeeSheetService = employeeSheetService;
            this.taskService = taskService;
        }
        //api/v1/employee/getAll

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var startDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now;
            var response = new List<EmployeeView>();
            var employees = this.employeeService.GetEmployees();
            foreach (var emp in employees)
            {
                var sheets = this.employeeSheetService.GetTimeSheets(emp.Id).Where(t => t.WorkingDate >= startDate && t.WorkingDate <= endDate);
                var totalHours = sheets.Sum(t => t.WorkingHours);
                var daysWorked = sheets.GroupBy(t => t.WorkingDate).Count();
                var avrageHours = 0;
                if (daysWorked != 0)
                {
                    avrageHours = totalHours / daysWorked;
                }

                response.Add(new EmployeeView()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Code = emp.Code,
                    WeeklyAvrage = avrageHours,
                    WeeklyTotal = totalHours
                });
            }
            return new ObjectResult(response);

           
        }

        [HttpGet("getalltasks")]
        public IActionResult GETALLTASKS()
        {
            var items = this.taskService.GetTasks();
            return new ObjectResult(items);
        }

        [HttpPost("saveSheet")]
        public IActionResult SaveSheet(NewSheetView model)
        {
            return new ObjectResult(employeeSheetService.SaveSheet(model));
        }

        [HttpGet("getEmployeeSheets/{id}")]
        public IActionResult GetEmployeeSheets(int id)
        {
            var startDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now;
            var response = new List<EmployeeTaskView>();
            var sheets = this.employeeSheetService.GetTimeSheets(id).Where(t => t.WorkingDate >= startDate && t.WorkingDate <= endDate);
            foreach (var taskGroup in sheets.GroupBy(t => t.Task))
            {
                response.Add(new EmployeeTaskView()
                {
                    Task = taskGroup.Key.Name,
                    SundayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Sunday).Sum(t => t.WorkingHours),
                    MondayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Monday).Sum(t => t.WorkingHours),
                    TuesdayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Tuesday).Sum(t => t.WorkingHours),
                    WenesdayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Wednesday).Sum(t => t.WorkingHours),
                    ThursdayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Thursday).Sum(t => t.WorkingHours),
                    FridayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Friday).Sum(t => t.WorkingHours),
                    SaturdayHours = taskGroup.Where(t => t.WorkingDate.DayOfWeek == DayOfWeek.Saturday).Sum(t => t.WorkingHours),
                });
            }
            return new ObjectResult(response);
        }
    }
}