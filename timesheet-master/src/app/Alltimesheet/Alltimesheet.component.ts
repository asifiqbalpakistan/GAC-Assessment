import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'Alltimesheet',
  templateUrl: './Alltimesheet.component.html',
  styleUrls: ['./Alltimesheet.component.scss']
})
export class TimesheetComponent implements OnInit {
  sheets: any=[];
  optionSelected: any;
  employees: any;
  constructor(private employeeService: EmployeeService, public activeRoute: ActivatedRoute, public _router: Router) {

  }

  ngOnInit() {
    let id = this.activeRoute.snapshot.paramMap.get("id")
    this.optionSelected = Number(id);

    this.getEmpSheet(id);
    this.employeeService.getallemployees().subscribe(data => {
      this.employees = data;
    });
  }

  getEmpSheet(id) {
    this.employeeService.getEmployeeSheets(id).subscribe(data => {
      this.sheets = data;
    });
  }

  onOptionsSelected(event) {
    this._router.navigate(['/Alltimesheet', event]);
    this.getEmpSheet(event);
  }

  redirectToNewTimeSheet() {
    console.log(this.optionSelected);
    this._router.navigate(['/createtimesheet',this.optionSelected]);

  }
  getSum(key: string): number {
    let sum = 0;
    for (let i = 0; i < this.sheets.length; i++) {
      sum += this.sheets[i][key];
    }
    return sum;
  }

}