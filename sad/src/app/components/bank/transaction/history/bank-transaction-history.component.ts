import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

import { Wallet } from '../../../shared/wallet.type';
import { TransactionLog } from '../../../shared/transaction-log.type';
import { TransactionLogService } from '../../../shared/transaction-log.service';

@Component({
    moduleId: module.id,
    selector: 'bank-transaction-history',
    templateUrl: 'bank-transaction-history.component.html',
    styleUrls: ['bank-transaction-history.component.css']
})

export class BankTransactionHistoryComponent implements OnInit {
    @Input() wallet: Wallet;
    transactionLogArr: TransactionLog[];

    constructor(private transactionLogService: TransactionLogService) {
    }

    ngOnInit() {
        this.transactionLogService.getAllCustomerTransaction(this.wallet.id)
            .then(transactionLogArr => {
                this.transactionLogArr = transactionLogArr;
            })
    }



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