"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var wallet_type_1 = require("../../../shared/wallet.type");
var transaction_log_service_1 = require("../../../shared/transaction-log.service");
var BankTransactionHistoryComponent = (function () {
    function BankTransactionHistoryComponent(transactionLogService) {
        this.transactionLogService = transactionLogService;
        this.visible = false;
        this.visibleAnimate = false;
    }
    BankTransactionHistoryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.transactionLogService.getAllCustomerTransaction(this.wallet.id)
            .then(function (transactionLogArr) {
            _this.transactionLogArr = transactionLogArr;
        });
    };
    BankTransactionHistoryComponent.prototype.show = function () {
        var _this = this;
        this.visible = true;
        setTimeout(function () { return _this.visibleAnimate = true; }, 100);
    };
    BankTransactionHistoryComponent.prototype.hide = function () {
        var _this = this;
        this.visibleAnimate = false;
        setTimeout(function () { return _this.visible = false; }, 300);
    };
    BankTransactionHistoryComponent.prototype.onContainerClicked = function (event) {
        if (event.target.classList.contains('modal')) {
            this.hide();
        }
    };
    return BankTransactionHistoryComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", wallet_type_1.Wallet)
], BankTransactionHistoryComponent.prototype, "wallet", void 0);
BankTransactionHistoryComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'bank-transaction-history',
        templateUrl: 'bank-transaction-history.component.html',
        styleUrls: ['bank-transaction-history.component.css']
    }),
    __metadata("design:paramtypes", [transaction_log_service_1.TransactionLogService])
], BankTransactionHistoryComponent);
exports.BankTransactionHistoryComponent = BankTransactionHistoryComponent;
//# sourceMappingURL=bank-transaction-history.component.js.map