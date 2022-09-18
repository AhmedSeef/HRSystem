import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  loggedin:any;
constructor(private auth:AuthService){
  this.loggedin = this.auth.checkLogin();
}
  AfterLogin(loged:any){
   this.loggedin = loged;
   
    console.log(loged);
  }
  AfterLogOut(logedout:any){
    this.loggedin = logedout;
  }
}
