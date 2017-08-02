
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Customer } from '../../shared/customer.type';
import { CustomerService } from '../../shared/customer.service';

@Component({
    moduleId: module.id,
    selector: 'customer-detail',
    templateUrl: 'customer-detail.component.html'
})
export class CustomerDetailComponent implements OnInit {

    @Input() customer: Customer;

    constructor(
        private accountService: CustomerService,
        private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        let id = this.activatedRoute.snapshot.params['id'] as string;
        this.accountService.getCustomer(id)
            .then(customer => this.customer = customer);
    }
}