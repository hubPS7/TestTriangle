import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, Validators, FormGroup } from '@angular/forms';
import { EmployeeService } from '../shared/employee.service';
import { EmployeeDetailsService } from '../shared/employee-details.service';
import { Router, ActivatedRoute, Params } from '@angular/router';   

import { GoogleLoginProvider, FacebookLoginProvider, AuthService } from 'angularx-social-login';    
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';    
import { Socialusers } from '../dashboard/dashboard.component'    
import { SocialloginService } from '../shared/sociallogin.service';    

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {
 
  response;    
  socialusers=new Socialusers();
  userName = "";    
  emailId = "";

  employeeDetailForm: FormArray = this.fb.array([]);
  countryList =[];
  notification =null;
  constructor(private fb: FormBuilder, 
    private empService: EmployeeService,
    private empdetailService : EmployeeDetailsService,
    private router: Router ,
    public OAuth: AuthService,    
    private SocialloginService: SocialloginService ) { }

  ngOnInit() {
    this.empService.getAllCountry().subscribe(res => this.countryList = res as [] );

    this.empdetailService.getAllEmployee().subscribe(res => {
      //debugger;
      if((res as []).length ===0){
        this.addEmployeeDetailForm();
      } 
      else{
        (res as []).forEach((empDetail : any) => {
          //debugger;
          this.employeeDetailForm.push(this.fb.group({
            EmployeeId:[empDetail.employeeId],
             FirstName : [empDetail.firstName, Validators.required]
            ,LastName : [empDetail.lastName, Validators.required]
            ,Title : [empDetail.title]
            ,Addresss: [empDetail.addresss, Validators.required]
            ,City: [empDetail.city, Validators.required]
            ,Region: [empDetail.region]
            ,PostalCode: [empDetail.postalCode]
            ,Country: [empDetail.country, Validators.min(1)]
            ,HomePhone: [empDetail.homePhone, Validators.required]
            ,CreatedBy: ['']
          }));
        })
      }
    })
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

  addEmployeeDetailForm()
  {
    this.employeeDetailForm.push(this.fb.group({
       EmployeeId:[0],
       FirstName : ['', Validators.required]
      ,LastName : ['', Validators.required]
      ,Title : ['']
      ,Addresss: ['', Validators.required]
      ,City: ['', Validators.required]
      ,Region: ['']
      ,PostalCode: ['']
      ,Country: ['', Validators.min(1)]
      ,HomePhone: ['', Validators.required] 
      ,CreatedBy: ['']
    }));
  }
  submitEmpRecord (fg:FormGroup){
    //debugger;
    var d = fg.value.EmployeeId;
    d = fg.value.employeeId;
    d = fg.value.EmployeeId;
    if(fg.value.EmployeeId == 0)
      this.empdetailService.AddEmployee(fg.value).subscribe((res:any) => {
        debugger;
        fg.patchValue({EmployeeId : res.employeeId});
        this.showNotification('insert');
    })
    else
       this.empdetailService.UpdateEmployee(fg.value).subscribe((res:any) => {
        this.showNotification('update');
    })
  }

  deleteEmployee(EmployeeId, i){
    if(EmployeeId == 0){
      this.employeeDetailForm.removeAt(i);
      if(this.employeeDetailForm.length == 0)
        this.addEmployeeDetailForm();
    }
    else if(confirm('Are you sure you want to delete!!'))
      this.empdetailService.DeleteEmployee(EmployeeId).subscribe(
         res =>{
            this.employeeDetailForm.removeAt(i);
            this.showNotification('delete');
            if(this.employeeDetailForm.length ==0)
              this.addEmployeeDetailForm();
        });
  }

  showNotification(category){
    //debugger;
    switch (category) {
      case 'insert':
        this.notification={class :'text-success', message: 'Saved Data!!!'}
        break;
        case 'update':
        this.notification={class :'text-primary', message: 'Data Updated Successfully!!!'}
        break;
        case 'delete':
        this.notification={class :'text-danger', message: 'Data Deleted Successfully!!!'}
        break;
    
      default:
        break;
    }
    setTimeout(() => {
      this.notification = null;
    }, 3000);
  }
}
