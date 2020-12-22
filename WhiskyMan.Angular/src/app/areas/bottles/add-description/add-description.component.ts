import { OverlyingAlertService } from './../../x_shared/services/overlying-alert/overlying-alert.service';
import { BottleDescriptionDataService } from './../x_shared/sevices/bottle-description-data.service';
import { BottleDescriptionForEdit } from './../x_models/bottle-description-for-edit';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { OverlayingSpinnerService } from '../../x_shared/services/overlaying-spiner/overlaying-spinner.service';

@Component({
  selector: 'app-add-description',
  templateUrl: './add-description.component.html',
  styleUrls: ['./add-description.component.css']
})
export class AddDescriptionComponent implements OnInit {

  constructor(
    private router: Router,
    private spinnerService: OverlayingSpinnerService,
    private descriptioService: BottleDescriptionDataService,
    private alertService: OverlyingAlertService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(description: BottleDescriptionForEdit): void {
    console.log(description);
    this.spinnerService.showSpinner();
    this.descriptioService.addBottleDescription(description)
      .subscribe(response => {
        this.alertService.addSucces('Bottle description successfully added', true);
        this.router.navigate(['bottles', 'description-detail', response.descriptionId]);
      },
      err => {
        this.spinnerService.hideSpiner();
        this.alertService.addError(`Unable to create bottle description (error: ${err.error})`);
      });
  }
}
