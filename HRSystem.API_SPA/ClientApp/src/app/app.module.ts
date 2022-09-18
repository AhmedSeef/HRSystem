import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {NgxPaginationModule} from 'ngx-pagination';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';




import { LogInComponent } from './log-in/log-in.component';
import { HomeComponent } from './home/home.component';
import { HomePageComponent } from './home-page/home-page.component';
import { UsersComponent } from './users/users.component';
import { TransactionsComponent } from './Transactions/Transactions.component';
import { CreateUserComponent } from './users/create-user/create-user.component';
import { OrderBy } from './orderBy.pipe';




@NgModule({
  declarations: [	
    AppComponent,
    NavMenuComponent,
    HomeComponent,   
    LogInComponent,
    HomePageComponent,
    UsersComponent,
    TransactionsComponent,
    CreateUserComponent,
    OrderBy
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'transactions', component: TransactionsComponent },
      { path: 'users', component: UsersComponent },
      { path: 'create-user', component: CreateUserComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
