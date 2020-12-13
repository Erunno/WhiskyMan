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

@NgModule({
  declarations: [
    BottlesComponent,
    AddBottleComponent,
    AddDescriptionComponent,
    AllListComponent,
    MyListComponent,
    BottleViewCardComponent,
    BottlesListComponent
  ],
  imports: [
    CommonModule,
    BottlesRoutingModule,
    SharedModule,
    HttpClientModule
  ],
  exports: [
    BottlesRoutingModule
  ]
})
export class BottlesModule { }
