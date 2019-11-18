import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmployeeActivityFormComponent } from './add-employee-activity-form.component';

describe('AddEmployeeActivityFormComponent', () => {
  let component: AddEmployeeActivityFormComponent;
  let fixture: ComponentFixture<AddEmployeeActivityFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEmployeeActivityFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEmployeeActivityFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
