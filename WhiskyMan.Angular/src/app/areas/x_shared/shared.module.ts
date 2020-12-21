import { TopAlertComponent } from './components/overlying-alert/top-alert.component';
import { OverlyingAlertService } from './services/overlying-alert/overlying-alert.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './services/auth/auth-http-iterceptor';
import { OverlayingSpinerComponent } from './components/overlaying-spiner/overlaying-spiner.component';
import { ValidationMessageComponent } from './components/validation-message/validation-message.component';
import { OverlayingSpinnerService } from './services/overlaying-spiner/overlaying-spinner.service';

@NgModule({
  declarations: [
    NavbarComponent,
    SidebarComponent,
    OverlayingSpinerComponent,
    ValidationMessageComponent,
    TopAlertComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavbarComponent,
    SidebarComponent,
    OverlayingSpinerComponent,
    TopAlertComponent,
    ValidationMessageComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ]
})
export class SharedModule { }
