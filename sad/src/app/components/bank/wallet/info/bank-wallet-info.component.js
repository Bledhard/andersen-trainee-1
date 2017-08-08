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
var BankWalletInfoComponent = (function () {
    function BankWalletInfoComponent(modalService) {
        this.modalService = modalService;
    }
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
    __metadata("design:paramtypes", [modal_service_1.ModalService])
], BankWalletInfoComponent);
exports.BankWalletInfoComponent = BankWalletInfoComponent;
var ModalComponent = (function () {
    function ModalComponent() {
        this.visible = false;
        this.visibleAnimate = false;
    }
    ModalComponent.prototype.show = function () {
        var _this = this;
        this.visible = true;
        setTimeout(function () { return _this.visibleAnimate = true; }, 100);
    };
    ModalComponent.prototype.hide = function () {
        var _this = this;
        this.visibleAnimate = false;
        setTimeout(function () { return _this.visible = false; }, 300);
    };
    ModalComponent.prototype.onContainerClicked = function (event) {
        if (event.target.classList.contains('modal')) {
            this.hide();
        }
    };
    return ModalComponent;
}());
ModalComponent = __decorate([
    core_1.Component({
        selector: 'app-modal',
        template: "\n  <div (click)=\"onContainerClicked($event)\" class=\"modal fade\" tabindex=\"-1\" [ngClass]=\"{'in': visibleAnimate}\"\n       [ngStyle]=\"{'display': visible ? 'block' : 'none', 'opacity': visibleAnimate ? 1 : 0}\">\n    <div class=\"modal-dialog\">\n      <div class=\"modal-content\">\n        <div class=\"modal-body\">\n          <ng-content select=\".app-modal-body\"></ng-content>\n        </div>\n        <div class=\"modal-footer\">\n          <ng-content select=\".app-modal-footer\"></ng-content>\n        </div>\n      </div>\n    </div>\n  </div>\n  "
    })
], ModalComponent);
exports.ModalComponent = ModalComponent;
//# sourceMappingURL=bank-wallet-info.component.js.map