import { AlertType } from './../../x_shared/components/top-alert/alert-type';
import { AuthService } from './../../x_shared/services/auth/auth.service';
import { UserForLogin } from './../x_models/user-for-login';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Alert } from '../../x_shared/components/top-alert/alert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: UserForLogin = { username: '', password: '' };
  loading = false;

  alerts: Alert[] = [];

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  public login(): void {
    this.loading = true;
    this.authService.logIn(this.user,
      _ => {
        this.router.navigate(['bottles/all-active-list']);
        this.loading = false;
      },
      err => {
        this.alerts.push({ type: AlertType.Error, message: 'Wrong combination of username and password' });
        this.loading = false;
      });
  }
}
