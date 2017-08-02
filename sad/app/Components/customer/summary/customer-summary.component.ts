import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

import { Customer } from "../../shared/customer.type";

@Component({
    moduleId: module.id,
    selector: 'customer-summary',
    templateUrl: 'customer-summary.component.html',
    styleUrls: ['customer-summary.component.css']
})

export class CustomerSummaryComponent {
    @Input() customer: Customer;

    constructor(private router: Router) {
    }

    navigateToDetail() {
        this.router.navigate(['detail', this.customer.id]);
    }
}