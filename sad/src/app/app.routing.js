"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
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
        redirectTo: 'ex'
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map