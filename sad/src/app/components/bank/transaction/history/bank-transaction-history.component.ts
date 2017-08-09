import { Component, Input, OnInit } from '@angular/core';

import { Wallet } from '../../../shared/wallet.type';
import { TransactionLog } from '../../../shared/transaction-log.type';
import { TransactionLogService } from '../../../shared/transaction-log.service';

@Component({
    moduleId: module.id,
    selector: 'bank-transaction-history',
    templateUrl: 'bank-transaction-history.component.html',
    styleUrls: ['bank-transaction-history.component.css']
})

export class BankTransactionHistoryComponent {
    @Input() transactionLogArr: TransactionLog[];

    constructor() {
    }
}