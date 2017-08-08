import { Component, Input } from '@angular/core';
import { Router, NavigationEnd } from "@angular/router";

import { BankTransactionHistoryComponent } from '../../transaction/history/bank-transaction-history.component';
import { Wallet } from '../../../shared/wallet.type';
import { ModalService } from '../../../shared/modal.service';


@Component({
    moduleId: module.id,
    selector: 'bank-wallet-info',
    templateUrl: 'bank-wallet-info.component.html',
    styleUrls: ['bank-wallet-info.component.css']
})
export class BankWalletInfoComponent {
    @Input() wallet: Wallet;

    constructor(private modalService: ModalService) {
    }
}

@Component({
    selector: 'app-modal',
    template: `
  <div (click)="onContainerClicked($event)" class="modal fade" tabindex="-1" [ngClass]="{'in': visibleAnimate}"
       [ngStyle]="{'display': visible ? 'block' : 'none', 'opacity': visibleAnimate ? 1 : 0}">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">
          <ng-content select=".app-modal-body"></ng-content>
        </div>
        <div class="modal-footer">
          <ng-content select=".app-modal-footer"></ng-content>
        </div>
      </div>
    </div>
  </div>
  `
})
export class ModalComponent {

    public visible = false;
    public visibleAnimate = false;

    public show(): void {
        this.visible = true;
        setTimeout(() => this.visibleAnimate = true, 100);
    }

    public hide(): void {
        this.visibleAnimate = false;
        setTimeout(() => this.visible = false, 300);
    }

    public onContainerClicked(event: MouseEvent): void {
        if ((<HTMLElement>event.target).classList.contains('modal')) {
            this.hide();
        }
    }
}