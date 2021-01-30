import { environment } from './../../../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserReference } from '../../models/user-reference';

@Injectable({
  providedIn: 'root'
})
export class GeneralUserService {

  private baseAddr = environment.apiUrl + 'users/';

  constructor(
    private http: HttpClient
  ) { }

  private cachedUsers: Observable<UserReference[]>;
  public getUserReferences(): Observable<UserReference[]> {

    if (!this.cachedUsers) {
      this.cachedUsers = this.http.get<UserReference[]>(this.baseAddr + 'active-references');
    }

    return this.cachedUsers;
  }
}
