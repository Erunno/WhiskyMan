import { BottleDetailComponent } from './bottle-detail/bottle-detail.component';
import { BottleDescriptionDetailComponent } from './bottle-description-detail/bottle-description-detail.component';
import { AddDescriptionComponent } from './add-description/add-description.component';
import { MyListComponent } from './my-list/my-list.component';
import { AllListComponent } from './all-list/all-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BottlesComponent } from './bottles.component';
import { AddBottleComponent } from './add-bottle/add-bottle.component';

const routes: Routes = [
  {
    path: 'bottles', component: BottlesComponent, children: [
      { path: 'all-active-list', component: AllListComponent },
      { path: 'my-list', component: MyListComponent },
      { path: 'add-description', component: AddDescriptionComponent },
      { path: 'add-bottle', component: AddBottleComponent },
      { path: 'description-detail/:id', component: BottleDescriptionDetailComponent },
      { path: 'bottle-detail/:id', component: BottleDetailComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class BottlesRoutingModule { }
