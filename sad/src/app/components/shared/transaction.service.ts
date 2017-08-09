import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { Transaction } from './transaction.type';

@Injectable()
export class TransactionService {
    constructor(private http: Http) {

    }

    getAllWalletTransaction(id: string) {
        return this.http.get(`api/transaction/wallet/${id}`)
            .map(response => response.json() as Transaction[])
            .toPromise();
    }
}