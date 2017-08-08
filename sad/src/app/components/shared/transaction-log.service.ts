import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { TransactionLog } from './transaction-log.type';

@Injectable()
export class TransactionLogService {
    constructor(private http: Http) {

    }

    getAllCustomerTransaction(id: number) {
        return this.http.get(`api/transaction/customer/${id}`)
            .map(response => response.json() as TransactionLog[])
            .toPromise();
    }
}