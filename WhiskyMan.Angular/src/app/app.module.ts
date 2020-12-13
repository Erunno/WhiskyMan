import { TransactionsModule } from './areas/transactions/transactions.module';
import { HomeModule } from './areas/home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './areas/x_shared/shared.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BottlesModule } from './areas/bottles/bottles.module';
import { UserModule } from './areas/user/user.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    NgbModule,
    HomeModule,
    BottlesModule,
    TransactionsModule,
    UserModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
