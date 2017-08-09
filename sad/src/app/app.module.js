"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
require("node_modules/hammerjs/hammer.js");
var app_component_1 = require("./components/app/app.component");
var app_routing_1 = require("./app.routing");
var header_component_1 = require("./components/shared/header/header.component");
var ex_list_component_1 = require("./components/ex/ex-list/ex-list.component");
var ex_summary_component_1 = require("./components/ex/ex-summary/ex-summary.component");
var ex_detail_component_1 = require("./components/ex/ex-detail/ex-detail.component");
var modal_component_1 = require("./components/shared/modal.component");
var customer_service_1 = require("./components/shared/customer.service");
var wallet_service_1 = require("./components/shared/wallet.service");
var transaction_service_1 = require("./components/shared/transaction.service");
var transaction_log_service_1 = require("./components/shared/transaction-log.service");
var modal_service_1 = require("./components/shared/modal.service");
var bank_account_list_component_1 = require("./components/bank/account/list/bank-account-list.component");
var bank_account_info_component_1 = require("./components/bank/account/info/bank-account-info.component");
var bank_account_form_component_1 = require("./components/bank/account/form/bank-account-form.component");
var bank_customer_info_component_1 = require("./components/bank/customer/info/bank-customer-info.component");
var bank_transaction_detail_component_1 = require("./components/bank/transaction/detail/bank-transaction-detail.component");
var bank_transaction_history_component_1 = require("./components/bank/transaction/history/bank-transaction-history.component");
var bank_transaction_summary_component_1 = require("./components/bank/transaction/summary/bank-transaction-summary.component");
var bank_transaction_last_component_1 = require("./components/bank/transaction/last/bank-transaction-last.component");
var bank_wallet_detail_component_1 = require("./components/bank/wallet/detail/bank-wallet-detail.component");
var bank_wallet_info_component_1 = require("./components/bank/wallet/info/bank-wallet-info.component");
var bank_wallet_list_component_1 = require("./components/bank/wallet/list/bank-wallet-list.component");
var bank_wallet_summary_component_1 = require("./components/bank/wallet/summary/bank-wallet-summary.component");
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
            bank_account_list_component_1.BankAccountListComponent,
            bank_account_info_component_1.BankAccountInfoComponent,
            bank_customer_info_component_1.BankCustomerInfoComponent,
            bank_transaction_detail_component_1.BankTransactionDetailComponent,
            bank_transaction_history_component_1.BankTransactionHistoryComponent,
            bank_transaction_summary_component_1.BankTransactionSummaryComponent,
            bank_transaction_last_component_1.BankTransactionLastComponent,
            bank_wallet_detail_component_1.BankWalletDetailComponent,
            bank_wallet_info_component_1.BankWalletInfoComponent,
            bank_wallet_list_component_1.BankWalletListComponent,
            bank_wallet_summary_component_1.BankWalletSummaryComponent,
            bank_account_form_component_1.BankAccountFormComponent,
            modal_component_1.ModalComponent
        ],
        imports: [
            http_1.HttpModule,
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            app_routing_1.routing,
        ],
        entryComponents: [
            bank_transaction_summary_component_1.BankTransactionSummaryComponent
        ],
        providers: [
            customer_service_1.CustomerService,
            wallet_service_1.WalletService,
            transaction_service_1.TransactionService,
            transaction_log_service_1.TransactionLogService,
            modal_service_1.ModalService
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map