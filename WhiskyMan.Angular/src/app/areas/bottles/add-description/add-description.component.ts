import { OverlyingAlertService } from './../../x_shared/services/overlying-alert/overlying-alert.service';
import { BottleDescriptionDataService } from './../x_shared/sevices/bottle-description-data.service';
import { BottleDescriptionForEdit } from './../x_models/bottle-description-for-edit';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { OverlayingSpinnerService } from '../../x_shared/services/overlaying-spiner/overlaying-spinner.service';
import { AlertType } from '../../x_shared/components/overlying-alert/alert-type';

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

  private alertAdded = false;

  onSubmit(description: BottleDescriptionForEdit) {
    this.spinnerService.showSpinner();
    this.descriptioService.addBottleDescription(description)
      .subscribe(response => {

        this.alertService.addAlert({
          message: "Bottle description successfully added",
          type: AlertType.Succes,
          surviveToNextPage: true
        });

        this.router.navigate(['bottles', 'description-detail', response.descriptionId])
      })
  }
}
