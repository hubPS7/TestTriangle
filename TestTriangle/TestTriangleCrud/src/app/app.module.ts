import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from "@angular/forms";
import { AppComponent } from './app.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GoogleLoginProvider,AuthService  } from 'angularx-social-login';
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login'; 
import { AppRoutingModule } from  '../app/app-routing.module';  
export function socialConfigs() {    
  const config = new AuthServiceConfig(    
    [      
      {    
        id: GoogleLoginProvider.PROVIDER_ID,    
        provider: new GoogleLoginProvider('1064828739026-hi52gk7cg2psb77qp5uskcqera5cq7io.apps.googleusercontent.com')    
      }    
    ]    
  );    
  return config;    
} 
@NgModule({
  declarations: [
    AppComponent,
    EmployeeDetailComponent,
    LoginComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule    
  ],
  providers: [
    AuthService,    
    {    
      provide: AuthServiceConfig,    
      useFactory: socialConfigs    
    }  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
