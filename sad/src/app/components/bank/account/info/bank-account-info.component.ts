﻿import { Component, Input, OnInit, HostBinding, ElementRef } from '@angular/core';
import { Customer } from '../../../shared/customer.type';
import { Wallet } from '../../../shared/wallet.type';
import { WalletService } from '../../../shared/wallet.service';

@Component({
    moduleId: module.id,
    selector: 'bank-account-info',
    templateUrl: 'bank-account-info.component.html',
    styleUrls: ['bank-account-info.component.css'],
})
export class BankAccountInfoComponent {
    @Input() customer: Customer;
    walletArr: Wallet[];

    constructor(private walletService: WalletService) {

    }

    //ngOnInit() {
    //    this.walletService.getWalletsByCustomerId(this.customer.id)
    //        .then(walletArr => {
    //            this.walletArr = walletArr;
    //        })
    //}

}