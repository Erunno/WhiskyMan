import { OverlayingSpinnerService } from './areas/x_shared/services/overlaying-spiner/overlaying-spinner.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'WhiskyMan';

  constructor(
    public spinnerService: OverlayingSpinnerService
  ) {}
}
