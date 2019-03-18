import { NgModule,APP_INITIALIZER } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimesheetComponent } from './Alltimesheet/Alltimesheet.component'
import { CreateTimesheetComponent } from './createtimesheet/createtimesheet.component'

import { EmployeeListComponent } from './employee/employee.component'



const appRoutes: Routes = [
    {path:'',redirectTo:'/employeelist',pathMatch:'full'},
    { path: 'employeelist', component: EmployeeListComponent },
    { path: 'Alltimesheet/:id', component: TimesheetComponent },
    { path: 'createtimesheet/:id', component: CreateTimesheetComponent },
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ],
    providers:[]
})
export class AppRoutingModule { }