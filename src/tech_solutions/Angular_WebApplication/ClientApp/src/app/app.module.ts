import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeroFormComponent } from './hero-form/hero-form.component';
import { AddEmployeeActivityFormComponent } from './add-employee-activity-form/add-employee-activity-form.component';
import { EmployeeActivityService } from './services/employee-activity-service';
import {HttpModule} from '@angular/http';
import { EmployeeActivityComponent } from './employee-activity/employee-activity.component';  

@NgModule({
    declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
        HeroFormComponent
        , AddEmployeeActivityFormComponent, EmployeeActivityComponent
      

  ],
    imports: [
        HttpModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,      
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
        { path: 'fetch-data', component: FetchDataComponent },
        { path: 'hero-form', component: HeroFormComponent }
        , { path: 'add-employee-activity', component: AddEmployeeActivityFormComponent }
        , { path: 'employee-activity', component: EmployeeActivityComponent }
    ])
  ],
    providers: [EmployeeActivityService],
  bootstrap: [AppComponent]
})
export class AppModule { }
