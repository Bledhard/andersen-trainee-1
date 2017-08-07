import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/Rx';


import { Wallet } from './wallet.type';

@Injectable()
export class WalletService {
    constructor(private http: Http) {

    }

    getWalletsByCustomerId(id: number) {
        return this.http.get(`api/wallet/customer/${id}`)
            .map(response => response.json() as Wallet[])
            .toPromise();
    }
}