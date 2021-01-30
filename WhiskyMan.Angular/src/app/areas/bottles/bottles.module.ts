import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BottlesComponent } from './bottles.component';
import { SharedModule } from './../x_shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BottlesRoutingModule } from './bottles-routing.module';
import { AddBottleComponent } from './add-bottle/add-bottle.component';
import { AddDescriptionComponent } from './add-description/add-description.component';
import { AllListComponent } from './all-list/all-list.component';
import { MyListComponent } from './my-list/my-list.component';
import { HttpClientModule } from '@angular/common/http';
import { BottleViewCardComponent } from './x_shared/components/bottle-view-card/bottle-view-card.component';
import { BottlesListComponent } from './x_shared/components/bottles-list/bottles-list.component';
import { BottleDescriptionEditComponent } from './x_shared/components/bottle-description-edit/bottle-description-edit.component';
import { BottleDescriptionDetailComponent } from './bottle-description-detail/bottle-description-detail.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { BottleEditComponent } from './x_shared/components/bottle-edit/bottle-edit.component';
import { BottleDetailComponent } from './bottle-detail/bottle-detail.component';
import { PaymentConfirmationComponent } from './x_shared/components/bottle-view-card/payment-confirmation/payment-confirmation.component';

@NgModule({
  declarations: [
    BottlesComponent,
    AddBottleComponent,
    AddDescriptionComponent,
    AllListComponent,
    MyListComponent,
    BottleViewCardComponent,
    BottlesListComponent,
    BottleDescriptionEditComponent,
    BottleDescriptionDetailComponent,
    BottleEditComponent,
    BottleDetailComponent,
    PaymentConfirmationComponent
  ],
  imports: [
    CommonModule,
    BottlesRoutingModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgSelectModule,
    FormsModule
  ],
  exports: [
    BottlesRoutingModule
  ]
})
export class BottlesModule { }
