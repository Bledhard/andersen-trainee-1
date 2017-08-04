import { Component } from '@angular/core';
import { Customer } from '../../../shared/customer.type';
import { CustomerService } from '../../../shared/customer.service';

@Component({
    moduleId: module.id,
    selector: 'bank-customer-info',
    templateUrl: 'bank-customer-info.component.html',
    styleUrls: ['bank-customer-info.component.css']
})
export class BankCustomerInfoComponent {

    customerList: Customer[];

    constructor(private customerService: CustomerService) {

    }

    ngOnInit() {
        this.customerService.getAllCustomers()
            .then(customerList => this.customerList = customerList);
    }
}