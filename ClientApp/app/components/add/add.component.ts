import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'add',
    templateUrl:'./add.component.html'
})
export class AddComponent {

    private employee: Employee;
    private project: Project;
    private error: string;

    private addEmployeeForm = this.fb.group({
       firstName: ["", Validators.required],
        lastName: ["", Validators.required]
    });

    private addProjectForm = this.fb.group({
        name: ["", Validators.required],
        description: ["", Validators.required]
    });

    constructor(public fb: FormBuilder, private http: Http) { }

    addEmployee() {

        this.http.get('/api/SampleData/addEmployee/' + this.addEmployeeForm.value.firstName + '/' + this.addEmployeeForm.value.lastName)
            .subscribe(result => {
                this.employee = result.json();
            });
    }

    addProject() {

        this.http.get('/api/SampleData/addProject/' + this.addProjectForm.value.name + '/' + this.addProjectForm.value.description)
            .subscribe(result => {
                if (result.json().error === "error") {
                    this.error = "Some trouble with your data. Please, try again.";
                }
                else {
                    this.project = result.json();
                }
            });
    }

}

interface Employee {
    firstName: string;
    lastName: string;
    id: string;
}

interface Project {
    name: string;
    description: string;
    id: string;
}