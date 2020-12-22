import { Router } from '@angular/router';
import { OverlyingAlertService } from './../../x_shared/services/overlying-alert/overlying-alert.service';
import { BottlesDataService } from './../x_shared/sevices/bottles-data.service';
import { OverlayingSpinnerService } from './../../x_shared/services/overlaying-spiner/overlaying-spinner.service';
import { BottleForEdit } from './../x_models/bottle-for-edit';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-bottle',
  templateUrl: './add-bottle.component.html',
  styleUrls: ['./add-bottle.component.css']
})
export class AddBottleComponent implements OnInit {

  constructor(
    private spinnerService: OverlayingSpinnerService,
    private bottleService: BottlesDataService,
    private alertService: OverlyingAlertService,
    private router: Router
  ) { }

  ngOnInit(): void {

  }

  onSubmit(bottle: BottleForEdit): void {
    this.spinnerService.showSpinner();

    this.bottleService.addBottle(bottle)
      .subscribe(response => {
        this.alertService.addSucces('Bottle description successfully added');
        this.router.navigate(['bottles', 'bottle-detail', response.bottleId]);
      },
      err => {
        this.spinnerService.hideSpiner();
        this.alertService.addError(`Unable to create bottle (error: ${err.error})`);
      });
  }
}
