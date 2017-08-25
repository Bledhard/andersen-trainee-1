"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var bank_account_list_component_1 = require("./components/bank/account/list/bank-account-list.component");
var appRoutes = [
    {
        path: '',
        component: bank_account_list_component_1.BankAccountListComponent,
        pathMatch: 'full'
    },
    {
        path: '**',
        redirectTo: ''
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map