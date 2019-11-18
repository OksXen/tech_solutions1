import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http'; //Npm install @angular/http@latest
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeActivityService } from '../services/employee-activity-service';

import { EmployeeActivity } from '../employee-activity';
@Component({
  selector: 'app-add-employee-activity-form',
  templateUrl: './add-employee-activity-form.component.html',
  styleUrls: ['./add-employee-activity-form.component.css']
})
export class AddEmployeeActivityFormComponent implements OnInit {
   
    employeeActivityForm = new FormGroup({
        firstName: new FormControl(''),
        lastName: new FormControl(''),
        emailAddress: new FormControl('', [Validators.email]),
        activityName: new FormControl(''),
        comments: new FormControl('',),
    });
    title: string = "Create";
    errorMessage: any;
  

    submitted = false;

    onSubmit() {
        this.submitted = true;

        if (!this.employeeActivityForm.valid) {
            return;
        }
        if (this.title == "Create") {
            this._employeeActivityService.saveEmployeeActivity(this.employeeActivityForm.value).subscribe((data) => {
                this._router.navigate(['/employee-activity']);
            }, error => this.errorMessage = error)
        } 

    }

    get f() { return this.employeeActivityForm.controls; }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.employeeActivityForm.value); }


    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute, private _employeeActivityService: EmployeeActivityService, private _router: Router) {
    //constructor() {
        this.employeeActivityForm = this._fb.group({
            firstName: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            emailAddress: ['', [Validators.required, Validators.email]],
            activityName: ['', [Validators.required]],
            comments: ['', []]
        });
    }

   

    ngOnInit() {
       this.employeeActivityForm = this._fb.group({
            firstName: ['', [Validators.required]],
           lastName: ['', [Validators.required]],
           emailAddress: ['', [Validators.required, Validators.email]],
            activityName: ['', [Validators.required]],
            comments: ['', []]
        });
  }

}
