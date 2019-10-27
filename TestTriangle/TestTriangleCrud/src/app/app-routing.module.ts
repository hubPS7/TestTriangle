import { NgModule } from '@angular/core';    
import { Routes, RouterModule } from '@angular/router';    
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component'; 
export const routes: Routes = [    
  {    
    path: '',    
    redirectTo: 'login',    
    pathMatch: 'full',    
  },    
  {    
    path: 'login',    
    component: LoginComponent,    
    data: {    
      title: 'Login Page'    
    }    
  },    
  {    
    path: 'Dashboard',    
    component: DashboardComponent,    
    data: {    
      title: 'Dashboard Page'    
    }    
  }, 
  {    
    path: 'employee-details',    
    redirectTo: 'employee-details',    
    pathMatch: 'full',     
  },      
];    
@NgModule({    
  imports: [RouterModule.forRoot(routes)],    
  exports: [RouterModule]    
})    
export class AppRoutingModule { }