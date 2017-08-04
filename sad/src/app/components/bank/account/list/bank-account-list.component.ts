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
        //this.customerArr = [
        //    {
        //        id: 1,
        //        name: "test",
        //        surname: "qwe",
        //        birthDate: new Date(),
        //        phone: "123",
        //        eMail: "zxc"
        //    },
        //    {
        //        id: 2,
        //        name: "asd",
        //        surname: "zxc",
        //        birthDate: new Date(),
        //        phone: "456",
        //        eMail: "qwe"
        //    }
        //]
    }

    ngOnInit() {
        this.customerService.getAllCustomers()
            .then(customerArr => {
                this.customerArr = customerArr;
            })
    }
}