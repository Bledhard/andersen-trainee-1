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
var ex_list_component_1 = require("./components/ex/ex-list/ex-list.component");
var bank_account_list_component_1 = require("./components/bank/account/list/bank-account-list.component");
var bank_transaction_history_component_1 = require("./components/bank/transaction/history/bank-transaction-history.component");
var bank_wallet_detail_component_1 = require("./components/bank/wallet/detail/bank-wallet-detail.component");
var appRoutes = [
    {
        path: '',
        redirectTo: 'ex',
        pathMatch: 'full'
    },
    {
        path: 'account',
        component: bank_account_list_component_1.BankAccountListComponent
    },
    {
        path: 'wallet/:id',
        component: bank_wallet_detail_component_1.BankWalletDetailComponent
    },
    {
        path: 'transaction-history/:id',
        component: bank_transaction_history_component_1.BankTransactionHistoryComponent
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
var AppRoutingModule = (function () {
    function AppRoutingModule() {
    }
    return AppRoutingModule;
}());
AppRoutingModule = __decorate([
    core_1.NgModule({
        imports: [
            router_1.RouterModule.forRoot(appRoutes)
        ],
        exports: [
            router_1.RouterModule
        ]
    })
], AppRoutingModule);
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map