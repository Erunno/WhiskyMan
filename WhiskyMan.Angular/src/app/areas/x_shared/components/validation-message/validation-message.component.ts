import { ValidationMessageDictionary, ElementSpecificMessageDictionary } from './validation-message-dictionary';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-validation-message',
  templateUrl: './validation-message.component.html',
  styleUrls: ['./validation-message.component.css']
})
export class ValidationMessageComponent implements OnInit {

  constructor() { }

  public get showErrMessages(): boolean {
    return this.formControl.invalid && this.formControl.touched;
  }

  @Input("using") public messages: ValidationMessageDictionary;
  @Input("for") public elementAccessor: string;
  @Input("in") public form: FormGroup;

  public formControl: FormControl;
  public errors: {[s: string]: boolean};

  private defaultMessages = {
    required: 'field is required',
    email: 'email has a wrong format',
    max: 'value has to be smaller',
    min: 'value has to be bigger'
    // you may add more
  };

  ngOnInit(): void {
    this.formControl = this.form.get(this.elementAccessor) as FormControl;

    if (!this.formControl) {
      console.error(`FormContorol '${this.elementAccessor}' does not exist in provided FormGroup`);
    }
  }

  public getErrorMsg(key: string): string {

    // user did not provided custom message for this error
    if (!this.messages || !this.messages[key]) {
      return this.getDefautFor(key);
    }

    // user provided one message for one error code (not element specific)
    if (this.messages[key] instanceof String) {
      return this.messages[key] as string;
    }

    // user provided dictionary for this error
    const dictionary = this.messages[key] as ElementSpecificMessageDictionary;
    return this.getMessageFromDictionary(key, dictionary);
  }

  private getMessageFromDictionary(key: string, dictionary: ElementSpecificMessageDictionary): string {
    const elemName = this.getElementName();
    const specificMsg = dictionary[elemName];
    if(specificMsg) {
      return specificMsg;
    }

    // user provided default message for this error
    const userDefault = dictionary['__default__'];
    if(userDefault) {
      return userDefault;
    }

    // user did not provided custom default or element specific message
    return this.getDefautFor(key);
  }

  private getElementName(): string {
    const splitedElemName = this.elementAccessor.split('.');
    return splitedElemName[splitedElemName.length - 1];
  }

  private getDefautFor(key: string): string {
    if (this.defaultMessages[key]) {
      return this.defaultMessages[key];
    }

    return key;
  }
}
