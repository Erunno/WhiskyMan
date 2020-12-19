import { AlertType } from './alert-type';
import { Component, Input, OnInit, Output } from '@angular/core';
import { Alert } from './alert';

@Component({
  selector: 'app-top-alert',
  templateUrl: './top-alert.component.html',
  styleUrls: ['./top-alert.component.css']
})
export class TopAlertComponent implements OnInit {

  @Input() alerts: Alert[];

  alertClasses: { [K in AlertType]: string } = {
    [AlertType.Error]: 'alert-danger',
    [AlertType.Succes]: 'alert-success',
    [AlertType.Warning]: 'alert-warning'
  };

  constructor() { }

  ngOnInit(): void {
    const s = AlertType.Succes;
  }

  remove(index: number): void {
    this.alerts.splice(index, 1);
  }

}
