import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

import { Customer } from './customer.type';

@Injectable()
export class CustomerService {
    constructor(private http: Http) {

    }

    getCustomer(id: string) {
        return this.http.get(`api/customer/${id}`)
    }

    getAllCustomers() {
        return this.http.get("api/customer")
    }

    updateCustomer(customer: Customer) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        const request = this.http.patch(`api/customer/`, JSON.stringify(customer), { headers: headers }).subscribe(result => { });
    }
}