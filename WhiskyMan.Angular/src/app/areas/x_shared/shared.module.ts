import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './services/auth/auth-http-iterceptor';
import { OverlayingSpinerComponent } from './components/overlaying-spiner/overlaying-spiner.component';
import { TopAlertComponent } from './components/overlying-alert/top-alert.component';

@NgModule({
  declarations: [
    NavbarComponent,
    SidebarComponent,
    OverlayingSpinerComponent,
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
    TopAlertComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ]
})
export class SharedModule { }
