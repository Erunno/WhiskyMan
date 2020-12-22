import { BottleForEdit } from './../../x_models/bottle-for-edit';
import { environment } from './../../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BottleForView } from '../../x_models/bottle-for-view';


@Injectable({
  providedIn: 'root'
})
export class BottlesDataService {

  private baseAddr: string;

  constructor(
    private http: HttpClient
  ) {
    this.baseAddr = environment.apiUrl + 'bottles/';
  }

  public getActiveBottlesForView(): Observable<BottleForView[]> {
    return this.http.get<BottleForView[]>(this.baseAddr + 'all-active');
  }

  public addBottle(bottle: BottleForEdit): Observable<{bottleId: number}>{
    return this.http.post<{bottleId: number}>(this.baseAddr + 'add-bottle', bottle);
  }
}
