import { Component, Input } from '@angular/core';
import { Router, NavigationEnd } from "@angular/router";

import { BankTransactionHistoryComponent } from '../../transaction/history/bank-transaction-history.component';
import { Wallet } from '../../../shared/wallet.type';
import { ModalService } from '../../../shared/modal.service';
import { TransactionLog } from '../../../shared/transaction-log.type';
import { TransactionLogService } from '../../../shared/transaction-log.service';


@Component({
    moduleId: module.id,
    selector: 'bank-wallet-info',
    templateUrl: 'bank-wallet-info.component.html',
    styleUrls: ['bank-wallet-info.component.css']
})
export class BankWalletInfoComponent {
    @Input() wallet: Wallet;
    transactionLogArr: TransactionLog[];

    constructor(private modalService: ModalService,
                private transactionLogService: TransactionLogService) {
    }

    ngOnInit() {
        if (this.wallet !== undefined) {
            this.transactionLogService.getWalletTransactionLog(this.wallet.Id)
                .then(transactionLogArr => {
                    this.transactionLogArr = transactionLogArr;
                })
        }
    }
}