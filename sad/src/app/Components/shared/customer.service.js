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
var http_1 = require("@angular/http");
require("rxjs/Rx");
var CustomerService = (function () {
    function CustomerService(http) {
        this.http = http;
    }
    CustomerService.prototype.getCustomer = function (id) {
        return this.http.get("api/customer/" + id)
            .map(function (response) { return response.json(); })
            .toPromise();
    };
    CustomerService.prototype.getAllCustomers = function () {
        return this.http.get("api/customer")
            .map(function (response) { return response.json(); })
            .toPromise();
    };
    CustomerService.prototype.updateCustomer = function (customer) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var request = this.http.patch("api/customer/", JSON.stringify(customer), { headers: headers }).subscribe(function (result) { });
    };
    return CustomerService;
}());
CustomerService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], CustomerService);
exports.CustomerService = CustomerService;
//# sourceMappingURL=customer.service.js.map