import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { HeaderComponent } from './components/shared/header/header.component';

import { ExListComponent } from './components/ex/ex-list/ex-list.component';
import { ExSummaryComponent } from './components/ex/ex-summary/ex-summary.component';
import { ExDetailComponent } from './components/ex/ex-detail/ex-detail.component';

import { AccountCustomerListComponent} from './components/account/customer-list/account-customer-list.component';
import { AccountWalletComponent } from './components/account/wallet/account-wallet.component';
import { AccountTransactionListComponent} from './components/account/transaction-list/account-transaction-list.component';

const appRoutes: Routes = [
    { 
        path: '', 
        redirectTo: 'ex', 
        pathMatch: 'full' },
    { 
        path: 'account', 
        component: AccountCustomerListComponent
    },
    {
        path: 'wallet/:id',
        component: AccountWalletComponent
    },
    {
        path: 'transaction/:id',
        component: AccountTransactionListComponent
    },
    { 
        path: 'ex', 
        component: ExListComponent 
    },
    { 
        path: '**', 
        redirectTo: 'account' 
    }
];

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HeaderComponent,
        ExListComponent,
        ExDetailComponent,
        ExSummaryComponent,
        AccountCustomerListComponent,
        AccountWalletComponent,
        AccountTransactionListComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot(appRoutes)
    ]
})
export class AppModule {
}