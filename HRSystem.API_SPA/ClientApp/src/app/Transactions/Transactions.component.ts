import { Component, OnInit } from '@angular/core';
import { TransactionService } from '../services/transaction.service';

@Component({
  selector: 'app-Transactions',
  templateUrl: './Transactions.component.html',
  styleUrls: ['./Transactions.component.css']
})
export class TransactionsComponent implements OnInit {
  data:any;
  userId:Number;
  constructor(private trans:TransactionService) { }

  ngOnInit() {
    
    this.trans.getTransactions(Number(localStorage.getItem('UserId'))).subscribe(
      (response)=>{this.data = response}
    );
  }

}
