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
var customer_type_1 = require("../../../shared/customer.type");
var wallet_service_1 = require("../../../shared/wallet.service");
var modal_service_1 = require("../../../shared/modal.service");
var BankAccountInfoComponent = (function () {
    function BankAccountInfoComponent(walletService, modalService) {
        this.walletService = walletService;
        this.modalService = modalService;
    }
    BankAccountInfoComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.walletService.getWalletsByCustomerId(this.customer.Id)
            .then(function (walletArr) {
            _this.walletArr = walletArr;
        });
    };
    return BankAccountInfoComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", customer_type_1.Customer)
], BankAccountInfoComponent.prototype, "customer", void 0);
BankAccountInfoComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'bank-account-info',
        templateUrl: 'bank-account-info.component.html',
        styleUrls: ['bank-account-info.component.css'],
    }),
    __metadata("design:paramtypes", [wallet_service_1.WalletService,
        modal_service_1.ModalService])
], BankAccountInfoComponent);
exports.BankAccountInfoComponent = BankAccountInfoComponent;
//# sourceMappingURL=bank-account-info.component.js.map