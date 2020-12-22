import { FormControlsHelper } from './../../../../x_shared/helpers/form-controls-helper';
import { ValidationMessageDictionary } from './../../../../x_shared/components/validation-message/validation-message-dictionary';
import { BottleDescriptionForEdit } from './../../../x_models/bottle-description-for-edit';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Resources } from '../../../x_models/static-resources';

@Component({
  selector: 'app-bottle-description-edit',
  templateUrl: './bottle-description-edit.component.html',
  styleUrls: ['./bottle-description-edit.component.css']
})
export class BottleDescriptionEditComponent implements OnInit {

  public imagePlaceHolderUrl = Resources.bottleImgUrl;

  @Input() public bottleDesc: BottleDescriptionForEdit;
  @Output() public submitAndValidated: EventEmitter<BottleDescriptionForEdit> = new EventEmitter();

  form: FormGroup;

  public errorMessages: ValidationMessageDictionary = {
    max: {
      voltage: 'voltage has to be smaller than or equal to 100'
    },
    min: {
      voltage: 'voltage has to be bigger than or equal to 0',
      age: 'age have to be positive number'
    }
  };

  constructor() { }

  ngOnInit(): void {

    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      distillery: new FormControl(null, Validators.required),
      age: new FormControl(null, Validators.min(0)),
      voltage: new FormControl(null, [Validators.required, Validators.min(0), Validators.max(100)]),
      pictureUrl: new FormControl(null, Validators.required),
      descriptionText: new FormControl(null, Validators.required),
      region: new FormControl(null),
    });

  }

  public onSubmit(): void {
    if (this.form.valid) {
      this.submitAndValidated.emit(this.form.value);
    }
    else {
      FormControlsHelper.touchAllControls(this.form);
    }
  }
}
