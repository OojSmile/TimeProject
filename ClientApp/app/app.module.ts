import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { AddComponent } from './components/add/add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CheckEmployeeComponent } from './components/checkEmployee/checkEmployee.component';
import { CheckProjectComponent }  from './components/checkProject/checkProject.component';
import { UpdateComponent} from './components/update/update.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        AddComponent,
        CheckEmployeeComponent,
        CheckProjectComponent,
        UpdateComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'add', component: AddComponent },
            { path: 'checkEmployee', component: CheckEmployeeComponent },
            { path: 'checkProject', component: CheckProjectComponent },
            { path: 'update', component: UpdateComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
