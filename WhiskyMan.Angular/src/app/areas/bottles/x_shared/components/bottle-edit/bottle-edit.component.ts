import { GeneralBottleDescriptionService } from './../../../../x_shared/services/general-bottle-description/general-bottle-description.service';
import { ValidationMessageDictionary } from './../../../../x_shared/components/validation-message/validation-message-dictionary';
import { FormControlsHelper } from './../../../../x_shared/helpers/form-controls-helper';
import { GeneralUserService } from './../../../../x_shared/services/general-user/general-user.service';
import { UserReference } from './../../../../x_shared/models/user-reference';
import { OverlyingAlertService } from './../../../../x_shared/services/overlying-alert/overlying-alert.service';
import { BottleDescriptionDataService } from './../../sevices/bottle-description-data.service';
import { BottleDescriptionReference } from './../../../x_models/bottle-description-reference';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Resources } from '../../../x_models/static-resources';
import { BottleForEdit } from '../../../x_models/bottle-for-edit';

@Component({
  selector: 'app-bottle-edit',
  templateUrl: './bottle-edit.component.html',
  styleUrls: ['./bottle-edit.component.css']
})
export class BottleEditComponent implements OnInit {

  public imagePlaceHolderUrl = Resources.bottleImgUrl;
  public form: FormGroup;

  @Output() public submitAndValidated: EventEmitter<BottleForEdit> = new EventEmitter();

  public descriptionReferences: BottleDescriptionReference[] = [
    {id: 1, name: "octa", pictureUrl:"https://www.alkohol.cz/images/preview/thumb_340_380_1542816109DSC0002.jpg"},
    {id: 2, name: "glen", pictureUrl:"https://images-na.ssl-images-amazon.com/images/I/91dcnI0057L._AC_SL1500_.jpg"}
  ];
  public userReferences: UserReference[] = [
    {name: 'torouba', id: 1},
    {name: 'honza', id: 2},
    {name: 'prdel', id: 3},
  ];

  public errorMessages: ValidationMessageDictionary = {
    min: {
      amount_ml: 'Amount can\'t be negative',
      bottlePrice: 'bottle price can\'t be negative',
      shotPrice: 'shot price can\'t be negative',
      wastePercent: 'expected waste can\'t be negative'
    },
    max: {
      wastePercent: 'expected waste can\'t be bigger than 100'
    }
  };

  constructor(
    private generalDescriptionsService: GeneralBottleDescriptionService,
    private generalUserService: GeneralUserService,
    private alertService: OverlyingAlertService
  ) { }

  ngOnInit(): void {

    this.generalDescriptionsService.getDescriptionReferences()
      .subscribe(
        data => this.descriptionReferences = data,
        err => this.alertService.addError(
          `Unable to load bottle descriptions (error: ${err.message})`
        )
      );

    this.generalUserService.getUserReferences()
      .subscribe(
        data => this.userReferences = data,
        err => this.alertService.addError(
          `Unable to load users (error: ${err.message})`
        )
      );

    this.form = new FormGroup({
      owners: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.required),
      amount_ml: new FormControl(null, [Validators.required, Validators.min(0)]),
      bottlePrice: new FormControl(null, [Validators.required, Validators.min(0)]),
      shotPrice: new FormControl(null, [Validators.required, Validators.min(0)]),
      wastePercent: new FormControl(null, [Validators.required, Validators.min(0), Validators.max(100)]),
    });
  }

  public get descriptionUrl(): string {

    return this.form.value.description?.pictureUrl;
  }

  public onSubmit(): void {
    if (!this.form.valid) {
      FormControlsHelper.touchAllControls(this.form);
      return;
    }

    const val = this.form.value;

    this.submitAndValidated.emit({
      bottleDescriptionId: val.description.id as number,
      amount_ml: val.amount_ml as number,
      shotPrice: val.shotPrice as number,
      bottlePrice: val.bottlePrice as number,
      wastePercent: val.wastePercent as number,
      ownerIds: val.owners.map(o => o.id) as number[]
    });
  }

}
