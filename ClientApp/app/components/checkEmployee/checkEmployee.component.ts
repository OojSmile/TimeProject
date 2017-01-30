import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'check',
    templateUrl: './checkEmployee.component.html'
})
export class CheckEmployeeComponent {
    private projects: EmployeeProject [];
    private employeeProjectsInfo: EmployeeWithTime[];

    private employeeInfoForm = this.fb.group({
        employeeID: ["", Validators.required]
    });

    constructor(public fb: FormBuilder, private http: Http) {
        this.http.get('/api/SampleData/initEmployeeInfo').subscribe(
            result => {
                this.employeeProjectsInfo = result.json() as EmployeeWithTime[];
            });
    }

    getEmployeeInfo() {
        this.http.get('/api/SampleData/getEmployeeInfo/' + this.employeeInfoForm.value.employeeID).subscribe(
            result => {
                this.projects = result.json() as EmployeeProject[];
            });
    }
}

interface EmployeeProject
{
    projectName: string;
    employeeID: string; 
    time: number;

}

interface EmployeeWithTime
{
    firstName: string;
    lastName: string;
    employeeID: number;
    time: number;
}