import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './components/app/app.component';
import { AppRoutingModule } from './app-routing.module';

import { HeaderComponent } from './components/shared/header/header.component';

import { ExListComponent } from './components/ex/ex-list/ex-list.component';
import { ExSummaryComponent } from './components/ex/ex-summary/ex-summary.component';
import { ExDetailComponent } from './components/ex/ex-detail/ex-detail.component';

import { CustomerService } from './components/shared/customer.service';
import { WalletService } from './components/shared/wallet.service';
import { BankAccountListComponent } from './components/bank/account/list/bank-account-list.component';
import { BankAccountInfoComponent } from './components/bank/account/info/bank-account-info.component';
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
        ExListComponent,
        ExDetailComponent,
        ExSummaryComponent,
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
    ],
    imports: [
        HttpModule,
        BrowserModule,
        FormsModule,
        AppRoutingModule
    ],
    providers: [
        CustomerService,
        WalletService
    ]
})
export class AppModule {
}