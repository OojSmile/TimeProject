import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'check',
    templateUrl: './checkProject.component.html'
})
export class CheckProjectComponent {
    private projects: ProjectInfo[];
    

    private employeeInfoForm = this.fb.group({
        employeeID: ["", Validators.required]
    });

    constructor(public fb: FormBuilder, private http: Http) {
        this.http.get('/api/SampleData/initProjectInfo').subscribe(
            result => {
                this.projects = result.json() as ProjectInfo[];
            });
    }

   
}

interface ProjectInfo{
    name: string;
    description: string;
    time: number;
    employees: number;

}