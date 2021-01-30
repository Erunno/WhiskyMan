import { OverlyingAlertService } from './../../x_shared/services/overlying-alert/overlying-alert.service';
import { BottleForView } from './../x_models/bottle-for-view';
import { BottlesDataService } from './../x_shared/sevices/bottles-data.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-list',
  templateUrl: './all-list.component.html',
  styleUrls: ['./all-list.component.css']
})
export class AllListComponent implements OnInit {

  bottles: BottleForView[];

  constructor(
    private bottlesDataService: BottlesDataService,
    private alertService: OverlyingAlertService
  ) { }

  ngOnInit(): void {
    this.fetchBottles();
  }

  fetchBottles(): void {
    this.bottlesDataService.getActiveBottlesForView()
      .subscribe(
        data => this.bottles = data,
        err => this.alertService.addError(
          `Unable to load active bottles (error: ${err.message})`
        ));
  }

}
