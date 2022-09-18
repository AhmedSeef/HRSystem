import { Component, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isAdmin:boolean = Number(localStorage.getItem('userType')) === 0 ? true:false;
  @Output() logoutShowHide = new EventEmitter<any>();

  constructor(private auth: AuthService) { }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout() {

    this.auth.logOut(Number(localStorage.getItem('UserId'))).subscribe(
      () => {
        this.logoutShowHide.emit(false);
        this.auth.removeLocalStoragetoken();
      }
    )
  }
}
