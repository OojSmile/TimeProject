import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'update',
    templateUrl: './update.component.html'
})
export class UpdateComponent {

    private employeeProject: EmployeeProject;
    private projects: Project[];
    private error: string

    private addForm = this.fb.group({
        employeeID: ["", Validators.required],
        time: ["", Validators.required]
    });


    constructor(public fb: FormBuilder, private http: Http) {
        this.http.get('/api/SampleData/initUpdate').subscribe(result => { this.projects = result.json() as Project[]; });
        console.log(this.projects);
    }


    addTiming(value) {
        this.http.get('/api/SampleData/addTiming/' + value + '/' + this.addForm.value.employeeID + '/' + this.addForm.value.time)
            .subscribe(result => {
                if (result.json().error === "error") {
                    this.error = "Some trouble with your data. Please, try again.";
                }
                else {
                    this.employeeProject = result.json();
                }
            });
    }
   
   
}


interface Project {
    name: string;
    description: string;
    id: string;
}

interface EmployeeProject
{
    employeeId: number;
    projectName: string;
    time: number;
}