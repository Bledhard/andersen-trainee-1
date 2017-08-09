import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/Rx';

import { TransactionLog } from './transaction-log.type';

@Injectable()
export class TransactionLogService {
    constructor(private http: Http) {

    }

    getWalletTransactionLog(id: number) {
        return this.http.get(`api/transaction/wallet/${id}`)
            .map(response => response.json() as TransactionLog[])
            .toPromise();
    }
}