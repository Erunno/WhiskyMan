import { environment } from './../../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BottleDescriptionReference } from 'src/app/areas/bottles/x_models/bottle-description-reference';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeneralBottleDescriptionService {

  private baseAddr = environment.apiUrl + 'bottle-descriptions/';

  constructor(
    private http: HttpClient
  ) { }

  private cachedDescriptions: Observable<BottleDescriptionReference[]>;
  public getDescriptionReferences(): Observable<BottleDescriptionReference[]> {

    if(!this.cachedDescriptions) {
      this.cachedDescriptions = this.http.get<BottleDescriptionReference[]>(this.baseAddr + 'active-references');
    }

    return this.cachedDescriptions;
  }
}
