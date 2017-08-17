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
var modal_service_1 = require("../../../shared/modal.service");
var transaction_log_service_1 = require("../../../shared/transaction-log.service");
var BankWalletInfoComponent = (function () {
    function BankWalletInfoComponent(modalService, transactionLogService) {
        this.modalService = modalService;
        this.transactionLogService = transactionLogService;
    }
    BankWalletInfoComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.wallet !== undefined) {
            this.transactionLogService.getWalletTransactionLog(this.wallet.Id)
                .map(function (res) { return res.json(); })
                .subscribe(function (transactionLogArr) {
                _this.transactionLogArr = transactionLogArr;
            });
        }
    };
    return BankWalletInfoComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", wallet_type_1.Wallet)
], BankWalletInfoComponent.prototype, "wallet", void 0);
BankWalletInfoComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'bank-wallet-info',
        templateUrl: 'bank-wallet-info.component.html',
        styleUrls: ['bank-wallet-info.component.css']
    }),
    __metadata("design:paramtypes", [modal_service_1.ModalService,
        transaction_log_service_1.TransactionLogService])
], BankWalletInfoComponent);
exports.BankWalletInfoComponent = BankWalletInfoComponent;
//# sourceMappingURL=bank-wallet-info.component.js.map