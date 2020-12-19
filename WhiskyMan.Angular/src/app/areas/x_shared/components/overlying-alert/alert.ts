import { AlertType } from './alert-type';

export interface Alert {
  type: AlertType;
  message: string;
  surviveToNextPage?: boolean
}
