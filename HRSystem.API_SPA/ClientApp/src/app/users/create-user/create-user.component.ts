import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { usersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  model: any = {};
  errorMessage: string = "";
  userManagerCandadties:any=[];
  selectedManager:any={};
  constructor(private users: usersService,private router: Router) { }

  ngOnInit() {
    this.users.getLookUp().subscribe((response)=>{
      this.userManagerCandadties = response;
    })
  }
  create() {
console.log(this.model)
  }

  onChange(data:any){
   this.model.managerId = data.id
   this.model.type = 3
    this.users.register(this.model).subscribe(
      ()=>{
      this.router.navigateByUrl("users")
    },error=>{
      this.errorMessage=error.error;
    })
    console.log(this.selectedManager);
  }
  
}
