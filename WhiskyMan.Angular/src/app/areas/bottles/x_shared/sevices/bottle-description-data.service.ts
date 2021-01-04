import { BottleDescriptionReference } from './../../x_models/bottle-description-reference';
import { environment } from './../../../../../environments/environment.prod';
import { BottleDescriptionForEdit } from './../../x_models/bottle-description-for-edit';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TagReference } from '../../x_models/tag-reference';

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
    return this.http.post<{descriptionId: number}>(this.baseAddr + 'add-description', description);
  }

  public getActiveTags(): Observable<TagReference[]> {
    return this.http.get<TagReference[]>(this.baseAddr + 'active-tags');
  }
}
