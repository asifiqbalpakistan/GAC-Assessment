import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms'

import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee/employee.component';
import { EmployeeService } from './services/employee.service';
import {AppRoutingModule} from './app-routing-module'
import { TimesheetComponent } from './Alltimesheet/Alltimesheet.component'
import { CreateTimesheetComponent } from './createtimesheet/createtimesheet.component'


@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    TimesheetComponent,
    CreateTimesheetComponent  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    EmployeeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
