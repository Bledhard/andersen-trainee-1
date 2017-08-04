import { Component, Input } from '@angular/core';
import { CustomerService } from '../../shared/customer.service';
import { Router } from "@angular/router/src";
import { Customer } from '../../shared/customer.type';

@Component({
    moduleId: module.id,
    selector: 'customer-list',
    templateUrl: 'customer-list.component.html',
    styleUrls: ['customer-list.component.css']
})
export class CustomerListComponent {
    @Input() customerList: Customer[];

    constructor(private customerService: CustomerService) {
    }

    //ngOnInit() {
    //    this.customerService.getAllCustomers()
    //        .then(this.customerList = Customer[]);
    //}
}