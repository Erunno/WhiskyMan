import { FormGroup } from "@angular/forms";

export class FormControlsHelper{

  /**
   * Marks all controls in a form group as touched
   * (taken from https://stackoverflow.com/questions/40529817/reactive-forms-mark-fields-as-touched)
   * @param formGroup - The form group to touch
   */
  static touchAllControls(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach(control => {
      control.markAsTouched();

      if (control.controls) {
        this.touchAllControls(control);
      }
    });
  }
}
