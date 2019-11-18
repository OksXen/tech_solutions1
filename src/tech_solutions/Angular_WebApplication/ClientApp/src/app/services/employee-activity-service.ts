import {
    Injectable,
    Inject
} from '@angular/core';
import {
    Http,
    Response
} from '@angular/http';
import {
    Observable
} from 'rxjs/Observable'; //npm install --save rxjs-compat
import {
    Router
} from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
@Injectable()
export class EmployeeActivityService {
    myAppUrl: string = "";
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }
    getEmployeeActivities() {
        return this._http.get(this.myAppUrl + 'api/EmployeeActivityApi').map((response: Response) => response.json()).catch(this.errorHandler);
    }

    saveEmployeeActivity(employeeActivity: any) {
        return this._http.post(this.myAppUrl + 'api/EmployeeActivityApi/AddEmployeeActivityByBody', employeeActivity).map((response: Response) => response.json()).catch(this.errorHandler)
    }
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error.json().error || 'Server error');
    }
} 
