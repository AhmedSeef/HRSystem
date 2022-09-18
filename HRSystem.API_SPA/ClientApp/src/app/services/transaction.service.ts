import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  baseUrl = "https://localhost:44339/api/Transaction";
constructor(private http:HttpClient) { }

getTransactions(userId:number){
  var a = localStorage.getItem('token');
  var reqHeader = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + a
  });
  return this.http.get(this.baseUrl+"/"+userId, { headers: reqHeader });
}
}
