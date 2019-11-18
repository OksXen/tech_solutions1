import { Component, OnInit, Inject } from '@angular/core';
import {
    Http,
    Headers
} from '@angular/http';

import { EmployeeActivityService } from '../services/employee-activity-service';

import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-employee-activity',
  templateUrl: './employee-activity.component.html',
  styleUrls: ['./employee-activity.component.css']
})
export class EmployeeActivityComponent implements OnInit {
    public employeeActivitylist: EmployeeActivityList[];
    constructor(public http: Http, private _router: Router, private _employeeService: EmployeeActivityService) {
        this.getEmployeeActivities();
    }

    getEmployeeActivities() {
        this._employeeService.getEmployeeActivities().subscribe(data => this.employeeActivitylist = data)
        console.log(this.employeeActivitylist);
    }  

    ngOnInit() {

  }

}

interface EmployeeActivityList {
    ActivityId: number;
    FirstName: string;
    LastName: string;
    EmailAddress: string;
    Comments: string;    
} 
