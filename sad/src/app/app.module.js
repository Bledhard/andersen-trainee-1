"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var app_component_1 = require("./components/app/app.component");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var header_component_1 = require("./components/shared/header/header.component");
var ex_list_component_1 = require("./components/ex/ex-list/ex-list.component");
var ex_summary_component_1 = require("./components/ex/ex-summary/ex-summary.component");
var ex_detail_component_1 = require("./components/ex/ex-detail/ex-detail.component");
var account_customer_list_component_1 = require("./components/account/customer-list/account-customer-list.component");
var account_wallet_component_1 = require("./components/account/wallet/account-wallet.component");
var account_transaction_list_component_1 = require("./components/account/transaction-list/account-transaction-list.component");
var appRoutes = [
    {
        path: '',
        redirectTo: 'ex',
        pathMatch: 'full'
    },
    {
        path: 'account',
        component: account_customer_list_component_1.AccountCustomerListComponent
    },
    {
        path: 'wallet/:id',
        component: account_wallet_component_1.AccountWalletComponent
    },
    {
        path: 'transaction/:id',
        component: account_transaction_list_component_1.AccountTransactionListComponent
    },
    {
        path: 'ex',
        component: ex_list_component_1.ExListComponent
    },
    {
        path: '**',
        redirectTo: 'account'
    }
];
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        bootstrap: [app_component_1.AppComponent],
        declarations: [
            app_component_1.AppComponent,
            header_component_1.HeaderComponent,
            ex_list_component_1.ExListComponent,
            ex_detail_component_1.ExDetailComponent,
            ex_summary_component_1.ExSummaryComponent,
            account_customer_list_component_1.AccountCustomerListComponent,
            account_wallet_component_1.AccountWalletComponent,
            account_transaction_list_component_1.AccountTransactionListComponent
        ],
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            router_1.RouterModule.forRoot(appRoutes)
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map