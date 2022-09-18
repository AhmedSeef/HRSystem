import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserListDto } from '../Models/UserListDto';

@Injectable({
  providedIn: 'root'
})
export class usersService {
  baseUrl = "https://localhost:44339/api/Employees";

  constructor(private http: HttpClient) { }

  getEmployees() {
    var a = localStorage.getItem('token');
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + a
    });
    return this.http.get<UserListDto>(this.baseUrl, { headers: reqHeader });
  }

  getLookUp(){
    return this.http.get<UserListDto>(this.baseUrl+"/lookUp")
  }

  register(model:any){
    return this.http.post(this.baseUrl+"/register",model);
  }

}
