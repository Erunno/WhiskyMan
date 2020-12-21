import { UserForLogin } from './../../../user/x_models/user-for-login';
import { UserView } from './../../models/userView';
import { environment } from './../../../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { EventEmitter } from '@angular/core';
import { Action } from 'rxjs/internal/scheduler/Action';
import {UserForRegistration} from '../../../user/x_models/user-for-registration';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseAddr: string;

  constructor(
    private http: HttpClient
  ) {
    this.baseAddr = environment.apiUrl + 'auth/';
    this.loggedIn = false;

    const token = localStorage.getItem('jwt_token');

    if (token) {
      const decodedToken: any = jwt_decode(token);

      console.log(Date.now());
      if (decodedToken.exp < Date.now()) {
        this.loggedIn = true;
        this.loadUserView();
      }
    }
  }

  private loggedIn: boolean;
  private currLoggedUser: UserView;
  public error: any;

  public get isLoggedIn(): boolean {
    return this.loggedIn;
  }

  public get loggedUser(): UserView {
    return this.currLoggedUser;
  }

  public logIn(
    user: UserForLogin,
    successCallback?: (user: UserView) => void,
    errorCallback?: (error: any) => void
  ): void {
    this.http.post<{ token: string }>(this.baseAddr + 'login', user)
      .subscribe(
        response => {
          localStorage.setItem('jwt_token', response.token);
          this.loggedIn = true;

          this.loadUserView();
          if (successCallback) {
            successCallback(this.currLoggedUser);
          }
        },
        err => {
          this.error = err;
          if (errorCallback) {
            errorCallback(err);
          }
        });
  }

  private loadUserView(): void {
    const token = localStorage.getItem('jwt_token');
    const decodedToken: any = jwt_decode(token as string);

    this.http.get<UserView>(environment.apiUrl + `users/user-view/${decodedToken.nameid}`)
      .subscribe(user => this.currLoggedUser = user);
  }

  public logout(): void {
    localStorage.removeItem('jwt_token');
    this.loggedIn = false;
    this.currLoggedUser = null;
  }

  public register(
    user: UserForRegistration,
    successCallback?: (user: UserForRegistration) => void,
    errorCallback?: (error: any) => void
  ): void {
    this.http.post(this.baseAddr + 'register', user)
      .subscribe(
        () => {
          if (successCallback) {
            successCallback(user);
          }
        },
        err => {
          this.error = err;
          if (errorCallback) {
            errorCallback(err);
          }
        });
  }
}
