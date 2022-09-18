import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  model: any = {}
  logedin:boolean;
  @Output() showAndHide = new EventEmitter<any>();
  errorMessage:string="";
  
  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

  logIn() {
    this.errorMessage= "";   
    this.auth.login(this.model).subscribe(
      Response => {       
      this.auth.setLocalStoragetoken(Response);
        this.logedin = true;
        this.showAndHide.emit(this.logedin);
        this.auth.setLocalStorageUserId(Response);
       
      },error=>{
        this.errorMessage=error.error;       
      }
    );
  }
}
