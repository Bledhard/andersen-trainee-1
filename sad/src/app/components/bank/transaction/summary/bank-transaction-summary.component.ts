import { Component, Input } from '@angular/core';

import { TransactionLog } from '../../../shared/transaction-log.type';

@Component({
    moduleId: module.id,
    selector: '[bank-transaction-summary]',
    templateUrl: 'bank-transaction-summary.component.html',
    styleUrls: ['bank-transaction-summary.component.css']
})
export class BankTransactionSummaryComponent {

    @Input() transactionLog: TransactionLog;

    constructor() {
    }
}
