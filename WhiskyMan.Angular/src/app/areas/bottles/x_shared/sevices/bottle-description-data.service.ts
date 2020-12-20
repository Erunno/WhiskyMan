import { environment } from './../../../../../environments/environment.prod';
import { BottleDescriptionForEdit } from './../../x_models/bottle-description-for-edit';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BottleDescriptionDataService {

  private baseAddr: string;

  constructor(
    private http: HttpClient
  ) {
    this.baseAddr = environment.apiUrl + 'bottle-descriptions/';
  }

  public addBottleDescription(
    description: BottleDescriptionForEdit
  ): Observable<{descriptionId: number}> {
    return this.http.post<{descriptionId: number}>(this.baseAddr + 'add', description);
  }

}
