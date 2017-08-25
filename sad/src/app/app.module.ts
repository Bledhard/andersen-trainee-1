import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { DatepickerModule } from 'ng2-bootstrap';
import 'node_modules/hammerjs/hammer.js';

import { AppComponent } from './components/app/app.component';
import { routing } from './app.routing';

import { HeaderComponent } from './components/shared/header/header.component';
import { ModalComponent } from './components/shared/modal.component';

import { CustomerService } from './components/shared/customer.service';
import { WalletService } from './components/shared/wallet.service';
import { TransactionService } from './components/shared/transaction.service';
import { TransactionLogService } from './components/shared/transaction-log.service';
import { ModalService } from './components/shared/modal.service';

import { BankAccountListComponent } from './components/bank/account/list/bank-account-list.component';
import { BankAccountInfoComponent } from './components/bank/account/info/bank-account-info.component';
import { BankAccountFormComponent } from './components/bank/account/form/bank-account-form.component';

import { BankCustomerInfoComponent } from './components/bank/customer/info/bank-customer-info.component';

import { BankTransactionDetailComponent } from './components/bank/transaction/detail/bank-transaction-detail.component';
import { BankTransactionHistoryComponent } from './components/bank/transaction/history/bank-transaction-history.component';
import { BankTransactionSummaryComponent } from './components/bank/transaction/summary/bank-transaction-summary.component';
import { BankTransactionLastComponent } from './components/bank/transaction/last/bank-transaction-last.component';

import { BankWalletDetailComponent } from './components/bank/wallet/detail/bank-wallet-detail.component';
import { BankWalletInfoComponent } from './components/bank/wallet/info/bank-wallet-info.component';
import { BankWalletListComponent } from './components/bank/wallet/list/bank-wallet-list.component';
import { BankWalletSummaryComponent } from './components/bank/wallet/summary/bank-wallet-summary.component';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HeaderComponent,
        BankAccountListComponent,
        BankAccountInfoComponent,
        BankCustomerInfoComponent,
        BankTransactionDetailComponent,
        BankTransactionHistoryComponent,
        BankTransactionSummaryComponent,
        BankTransactionLastComponent,
        BankWalletDetailComponent,
        BankWalletInfoComponent,
        BankWalletListComponent,
        BankWalletSummaryComponent,
        BankAccountFormComponent,
        ModalComponent
    ],
    imports: [
        HttpModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        DatepickerModule.forRoot(),
        routing,
    ],
    entryComponents: [
        BankTransactionSummaryComponent
    ],
    providers: [
        CustomerService,
        WalletService,
        TransactionService,
        TransactionLogService,
        ModalService
    ]
})
export class AppModule {
}