import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserListDto } from '../Models/UserListDto';
import { OrderBy } from '../orderBy.pipe';
import { usersService } from '../services/users.service';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [ OrderBy ]
})
export class UsersComponent implements OnInit {
   users: any;
   order: string = '';
   p;
   usersShadow: any;

  constructor(private usersservice:usersService,private router: Router) { }

  ngOnInit() {
    this.usersservice.getEmployees().subscribe(
      (response)=>{
        this.users =this.usersShadow= response;      
        console.log( this.users)
      }
    );
  }

  onSearchChange(data:any){   
    this.users = this.users.filter(element => {    
      console.log(element.manager);     
      return element.manager == data.value;
    })
  }

  close(){
    this.users = this.usersShadow;
  }

  sendData(data:any){
    this.users = this.usersShadow;
    if(data.value !=""){
      this.onSearchChange(data)
    } 
  }
  sort(){
    
  }

  goAdd(){
    this.router.navigateByUrl("create-user")
  }

  sortByCol(name: string) {
    debugger;
    if(this.users.length > 0 ) {
      if(this.users.indexOf(name) !== -1){
        console.log('alreday includes name');
        this.users.pop();
      }else {
        console.log('not  includes name');
        this.users.push(name);
      }
    } else {
      this.users.push(name);
    }

    this.order = this.users.join();
   // this.orderBy.transform(this.ELEMENT_DATA, this.order);
    console.log(name, this.order);
  }
}
