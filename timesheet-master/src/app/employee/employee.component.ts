import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import {Router} from '@angular/router';

@Component({
    selector: 'employee-list',
    templateUrl: 'employee.component.html',
    styleUrls:['./employee.component.scss']
})

export class EmployeeListComponent implements OnInit {
    employees: any;
    constructor(private employeeService: EmployeeService,public _router: Router) { }

    ngOnInit() {
        this.employeeService.getallemployees().subscribe(data => {
            this.employees = data;
        });
    }

    redirectToTimesheet(id){
    this._router.navigate(['/Alltimesheet',id])
    }

    
}