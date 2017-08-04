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
var router_1 = require("@angular/router");
var customer_type_1 = require("../../shared/customer.type");
var CustomerSummaryComponent = (function () {
    function CustomerSummaryComponent(router) {
        this.router = router;
    }
    CustomerSummaryComponent.prototype.navigateToDetail = function () {
        this.router.navigate(['detail', this.customer.Id]);
    };
    return CustomerSummaryComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", customer_type_1.Customer)
], CustomerSummaryComponent.prototype, "customer", void 0);
CustomerSummaryComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'customer-summary',
        templateUrl: 'customer-summary.component.html',
        styleUrls: ['customer-summary.component.css']
    }),
    __metadata("design:paramtypes", [router_1.Router])
], CustomerSummaryComponent);
exports.CustomerSummaryComponent = CustomerSummaryComponent;
//# sourceMappingURL=customer-summary.component.js.map