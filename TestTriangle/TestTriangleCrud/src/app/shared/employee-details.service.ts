import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  constructor(private http: HttpClient) { }

  AddEmployee(formData){
    return this.http.post(environment.apiBaseURI + '/employee/addemployee', formData)
  }

  UpdateEmployee(formData){
    return this.http.put(environment.apiBaseURI + '/employee/'+ formData.EmployeeId, formData)
  }

  DeleteEmployee(EmployeeId){
    return this.http.delete(environment.apiBaseURI + '/employee/'+ EmployeeId)
  }

  getAllEmployee(){
    return this.http.get(environment.apiBaseURI + '/employee/getallemployee')
  }
}
