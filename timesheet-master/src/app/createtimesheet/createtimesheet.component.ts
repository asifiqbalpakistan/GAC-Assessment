import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'createtimesheet',
  templateUrl: './createtimesheet.component.html',
  styleUrls: ['./createtimesheet.component.scss']
})
export class CreateTimesheetComponent implements OnInit {
  sheets: any;
  optionSelected: any;
  optionSelectedTask: any;
  employees: any;
  tasks: any;
  sheet: any = {};
  currDate=new Date().toISOString().substring(0,10);
  constructor(private employeeService: EmployeeService, public activeRoute: ActivatedRoute, public _router: Router) {

  }

  ngOnInit() {
  let id = this.activeRoute.snapshot.paramMap.get("id")

    this.sheet.EmployeeId = Number(id);
    this.sheet.TaskId = 1;
    this.employeeService.getallemployees().subscribe(data => {
      this.employees = data;
    });

    this.employeeService.getalltasks().subscribe(data => {
      this.tasks = data;
    });


  }

  getEmployeeSheets(id) {
    this.employeeService.getEmployeeSheets(id).subscribe(data => {
      this.sheets = data;
      console.log(this.sheets);
    });
  }

  onOptionsSelected(event) {
    this.getEmployeeSheets(event);
  }

  saveSheet() {
    this.employeeService.saveSheet(this.sheet).subscribe(data => {
      this._router.navigate(['/Alltimesheet', this.sheet.EmployeeId])
    });

  }

}