import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TransactionForAddition } from '../../models/transaction-for-addition';
import { environment } from './../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GeneralTransactionService {

  private baseAddr = environment.apiUrl + 'transactions/';

  constructor(
    private http: HttpClient
  ) { }

  public addTransaction(transaction: TransactionForAddition): Observable<void> {
    return this.http.post<void>(this.baseAddr + 'add-one', transaction);
  }
}
