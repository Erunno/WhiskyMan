import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BottleForView } from 'src/app/areas/bottles/x_models/bottle-for-view';
import { TransactionForAddition } from 'src/app/areas/x_shared/models/transaction-for-addition';
import { AuthService } from 'src/app/areas/x_shared/services/auth/auth.service';
import { GeneralTransactionService } from 'src/app/areas/x_shared/services/general-transaction/general-transaction.service';
import { OverlayingSpinnerService } from 'src/app/areas/x_shared/services/overlaying-spiner/overlaying-spinner.service';
import { OverlyingAlertService } from 'src/app/areas/x_shared/services/overlying-alert/overlying-alert.service';

@Component({
  selector: 'app-payment-confirmation',
  templateUrl: './payment-confirmation.component.html',
  styleUrls: ['./payment-confirmation.component.css']
})
export class PaymentConfirmationComponent implements OnInit {

  @Input() public bottle: BottleForView;
  @Output() public transactionComplete = new EventEmitter();

  public amountMl = 20;
  public shots = 1;

  constructor(
    private alertService: OverlyingAlertService,
    private transactionService: GeneralTransactionService,
    private authService: AuthService,
    private spinner: OverlayingSpinnerService
  ) { }

  ngOnInit(): void {
  }

  public onSubmit(): void {
    this.spinner.showSpinner();

    const transaction: TransactionForAddition = {
      buyerId: this.authService.loggedUser.id,
      bottleId: this.bottle.id,
      amount_ml: this.amountMl
    };

    this.transactionService.addTransaction(transaction)
      .subscribe(
        _ => {
          this.alertService.addSucces(`You bought ${transaction.amount_ml}ml of ${this.bottle.name} ${this.bottle.distillery}`);
          this.transactionComplete.emit();
          this.spinner.hideSpiner();
        },
        err => {
          this.alertService.addError(`Error occured: ${err.message}`);
          this.spinner.hideSpiner();
        }
      );
  }

  public onClose(): void {
    this.transactionComplete.emit();
  }

  public onAmountMlChanged(): void {
    this.shots = this.amountMl / 20;
  }

  public onShotsChanged(): void {
    this.amountMl = this.shots * 20;
  }

  public get sufixOfShot(): string {
    return this.shots <= 1 ? '' : 's';
  }
}
