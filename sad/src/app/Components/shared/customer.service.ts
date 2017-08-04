import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { Customer } from './customer.type';

@Injectable()
export class CustomerService {
    constructor(private http: Http) {

    }

    getCustomer(id: string) {
        return this.http.get(`api/customer/${id}`)
            .map(response => response.json() as Customer)
            .toPromise();
    }

    getAllCustomers() {
        return this.http.get("api/customer")
            .map(response => response.json() as Customer[])
            .toPromise();
    }
}