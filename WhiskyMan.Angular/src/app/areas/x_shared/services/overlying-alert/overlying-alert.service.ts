import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Alert } from '../../components/overlying-alert/alert';
import { AlertType } from '../../components/overlying-alert/alert-type';

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

  public addSucces(message: string, surviveToNextPage?: boolean) {
    this.addAlert({
      message: message,
      type: AlertType.Succes,
      surviveToNextPage: surviveToNextPage
    });
  }

  public addError(message: string, surviveToNextPage?: boolean) {
    this.addAlert({
      message: message,
      type: AlertType.Error,
      surviveToNextPage: surviveToNextPage
    });
  }
}
