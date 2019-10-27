import { Component, OnInit } from '@angular/core';    
import { GoogleLoginProvider, FacebookLoginProvider, AuthService } from 'angularx-social-login';    
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';    
import { Socialusers } from '../dashboard/dashboard.component'    
import { SocialloginService } from '../shared/sociallogin.service';    
import { Router, ActivatedRoute, Params } from '@angular/router';    
@Component({    
  selector: 'app-login',    
  templateUrl: './login.component.html',    
  styleUrls: ['./login.component.css']    
})    
export class LoginComponent implements OnInit {    
    response;    
    socialusers=new Socialusers();
    userName = "";    
    emailId = "";
  constructor(    
    public OAuth: AuthService,    
    private SocialloginService: SocialloginService ,
    private router: Router    
  ) { }    
    
  ngOnInit() {    
  }    
  public socialSignIn(socialProvider: string) {    
    let socialPlatformProvider;    
     if (socialProvider === 'google') {  
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;    
    }    
    
    this.OAuth.signIn(socialPlatformProvider).then(socialusers => {    
      console.log(socialProvider, socialusers);    
      this.assignToLabel(socialusers);    
    });    
  } 
  
  public assignToLabel(socialusers)
  {
    debugger;
    this.userName = socialusers.name;
    this.emailId = socialusers.email;
    this.router.navigate(['/login'])
  }
} 