import { Component, OnInit } from '@angular/core';
import {UserForRegistration} from '../x_models/user-for-registration';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../../environments/environment.prod';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../x_shared/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: UserForRegistration = { firstName: '', lastName: '',  username: '', password: '', email: ''};
  baseAddr: string;
  err: any;
  form: any;
  confirmedPasswd: string;


  constructor(
    private authService: AuthService
  ) {
  }

  ngOnInit(): void {
    this.confirmedPasswd = '';
  }

  public register(): void{
    this.authService.register(this.user, x => console.log(x), ex => console.log(ex));
  }
}
