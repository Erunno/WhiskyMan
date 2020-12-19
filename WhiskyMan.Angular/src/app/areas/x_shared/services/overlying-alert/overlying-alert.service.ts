import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Alert } from '../../components/overlying-alert/alert';

@Injectable({
  providedIn: 'root'
})
export class OverlyingAlertService {

  private alerts: Alert[] = [];

  constructor(
    router: Router
  )  {
    router.events.subscribe(
      _ => {
        this.alerts = this.alerts.filter((alert, _, __) => alert.surviveToNextPage)
      }
    )
  }

  public get activeAlerts(): Alert[] {
    return this.alerts;
  }

  public addAlert(alert: Alert) {
    this.alerts.push(alert);
  }
}
