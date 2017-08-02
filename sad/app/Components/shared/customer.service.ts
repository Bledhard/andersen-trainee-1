import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { Customer } from './customer.type';

@Injectable()
export class CustomerService {
    constructor(private http: Http) {

    }

    getCustomer(id: string) {
        return this.http.get(`api/customer/get/${id}`) // note string interpolation
            .map(response => response.json() as Customer)
            .toPromise();
    }
}