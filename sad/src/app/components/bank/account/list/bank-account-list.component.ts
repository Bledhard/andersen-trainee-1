import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../shared/customer.type';
import { CustomerService } from '../../../shared/customer.service';

@Component({
    moduleId: module.id,
    selector: 'bank-account-list',
    templateUrl: 'bank-account-list.component.html'
})
export class BankAccountListComponent {
    customerArr: Customer[];

    constructor(private customerService: CustomerService) {       
    }

    ngOnInit() {
        this.customerService.getAllCustomers()
            .map(res => res.json())
            .subscribe(customerArr => {
                this.customerArr = customerArr;
            })
    }
}