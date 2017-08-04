import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../shared/customer.type';
import { CustomerService } from '../../../shared/customer.service';

@Component({
    moduleId: module.id,
    selector: 'bank-account-list',
    templateUrl: 'bank-account-list.component.html',
    styleUrls: ['bank-account-list.component.css']
})
export class BankAccountListComponent {
    customerArr: Customer[];

    constructor(private customerService: CustomerService) {       
    }

    ngOnInit() {
        this.customerService.getAllCustomers()
            .then(customerArr => {
                this.customerArr = customerArr;
            })
    }
}