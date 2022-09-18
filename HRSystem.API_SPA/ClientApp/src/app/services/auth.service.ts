import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = "https://localhost:44339/api/Employees"
  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + "/login", model);
  }

  logOut(userId:Number){
    return this.http.get(this.baseUrl + "/LogOut/"+userId);
  }

  setLocalStoragetoken(tokenData: any) {   
    localStorage.setItem('token', tokenData.token);
  }

  getLocalStoragetoken() {
    return localStorage.getItem('token');
  }

  removeLocalStoragetoken() {
    localStorage.removeItem('token');
    localStorage.clear();
  }

  checkLogin(){
    if (localStorage.getItem("token") === null) {
      return false;
    }else{
      return true;
    }
  }

  setLocalStorageUserId(tokenData: any){
    console.log(tokenData);
    localStorage.setItem('UserId', tokenData.userID); 
    localStorage.setItem('userType', tokenData.userType);   
  }

  

}
