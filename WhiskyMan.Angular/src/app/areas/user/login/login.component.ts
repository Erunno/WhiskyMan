import { OverlyingAlertService } from './../../x_shared/services/overlying-alert/overlying-alert.service';
import { OverlayingSpinnerService } from './../../x_shared/services/overlaying-spiner/overlaying-spinner.service';
import { AlertType } from '../../x_shared/components/overlying-alert/alert-type';
import { AuthService } from './../../x_shared/services/auth/auth.service';
import { UserForLogin } from './../x_models/user-for-login';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Alert } from '../../x_shared/components/overlying-alert/alert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: UserForLogin = { username: '', password: '' };

  constructor(
    private authService: AuthService,
    private router: Router,
    private spinnerService: OverlayingSpinnerService,
    private alertService: OverlyingAlertService
  ) { }

  ngOnInit(): void {
  }

  public login(): void {
    this.spinnerService.showSpinner(30); // 30 is topPercent

    this.authService.logIn(this.user,
      _ => {
        this.router.navigate(['bottles/all-active-list']);
      },
      err => {
        this.alertService.addAlert({ type: AlertType.Error, message: 'Wrong combination of username and password'});
        this.spinnerService.hideSpiner();
      });
  }
}
