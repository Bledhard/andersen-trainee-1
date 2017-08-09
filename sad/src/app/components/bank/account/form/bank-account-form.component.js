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
var forms_1 = require("@angular/forms");
var customer_type_1 = require("../../../shared/customer.type");
var customer_service_1 = require("../../../shared/customer.service");
var BankAccountFormComponent = (function () {
    function BankAccountFormComponent(fb, customerService) {
        this.fb = fb;
        this.customerService = customerService;
        this.nameChangeLog = [];
        this.createForm();
        this.logNameChange();
    }
    BankAccountFormComponent.prototype.ngOnChanges = function () {
        this.customerForm.reset({
            name: this.customer.FirstName,
            surname: this.customer.Surname,
            birthDate: this.customer.BirthDate,
            phone: this.customer.Phone,
            eMail: this.customer.EMail
        });
    };
    BankAccountFormComponent.prototype.createForm = function () {
        this.customerForm = this.fb.group({
            name: ['', forms_1.Validators.compose([forms_1.Validators.required,
                    forms_1.Validators.minLength(4), this.forbiddenNameValidator(/admin/i)])],
            surname: ['', forms_1.Validators.required],
            birthDate: '',
            phone: '',
            eMail: ''
        });
    };
    BankAccountFormComponent.prototype.logNameChange = function () {
        var _this = this;
        var nameControl = this.customerForm.get('name');
        nameControl.valueChanges.forEach(function (value) { return _this.nameChangeLog.push(value); });
    };
    BankAccountFormComponent.prototype.onSubmit = function () {
        this.customer = this.prepareSaveCustomer();
        this.customerService.updateCustomer(this.customer);
        this.ngOnChanges();
    };
    BankAccountFormComponent.prototype.prepareSaveCustomer = function () {
        var formModel = this.customerForm.value;
        // return new `Customer` object containing a combination of original customer value(s)
        // and deep copies of changed form model values
        var saveCustomer = {
            Id: this.customer.Id,
            FirstName: formModel.name,
            Surname: formModel.surname,
            BirthDate: formModel.birthDate,
            Phone: formModel.phone,
            EMail: formModel.eMail
        };
        return saveCustomer;
    };
    BankAccountFormComponent.prototype.revert = function () { this.ngOnChanges(); };
    BankAccountFormComponent.prototype.forbiddenNameValidator = function (nameRe) {
        return function (control) {
            var forbidden = nameRe.test(control.value);
            return forbidden ? { 'forbiddenName': { value: control.value } } : null;
        };
    };
    return BankAccountFormComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", customer_type_1.Customer)
], BankAccountFormComponent.prototype, "customer", void 0);
BankAccountFormComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'bank-account-form',
        templateUrl: 'bank-account-form.component.html',
        styleUrls: ['bank-account-form.component.css']
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder,
        customer_service_1.CustomerService])
], BankAccountFormComponent);
exports.BankAccountFormComponent = BankAccountFormComponent;
//# sourceMappingURL=bank-account-form.component.js.map