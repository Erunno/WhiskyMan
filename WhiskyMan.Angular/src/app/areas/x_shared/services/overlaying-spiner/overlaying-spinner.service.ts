import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OverlayingSpinnerService {

  private isShown = false;
  private top = 50;

  constructor(
    router: Router
  ) {
    router.events.subscribe(
      _ => this.isShown = false
    )
  }

  public get spinnerIsShown(): boolean {
    return this.isShown;
  }

  public get topPercent(): number {
    return this.top;
  }

  public showSpinner(topPercent?: number): void  {
    this.top = topPercent ? topPercent : 50;
    this.isShown = true;
  }

  public hideSpiner(): void {
    this.isShown = false;
  }
}
