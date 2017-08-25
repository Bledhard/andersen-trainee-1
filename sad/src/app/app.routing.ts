import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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


const appRoutes: Routes = [
    { 
        path: '',
        component: BankAccountListComponent,
        pathMatch: 'full' },
    { 
        path: '**', 
        redirectTo: '' 
    }
];

export const routing = RouterModule.forRoot(appRoutes);