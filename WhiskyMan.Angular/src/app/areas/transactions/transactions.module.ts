import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionRoutingModule } from './transaction-routing.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TransactionRoutingModule
  ],
  exports: [
    TransactionRoutingModule
  ]
})
export class TransactionsModule { }
