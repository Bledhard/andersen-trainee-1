import { Component, Input, OnInit, OnChanges  } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ValidatorFn, AbstractControl } from "@angular/forms";

import { Customer } from '../../../shared/customer.type';
import { CustomerService } from '../../../shared/customer.service';

@Component({
    moduleId: module.id,
    selector: 'bank-account-form',
    templateUrl: 'bank-account-form.component.html',
    styleUrls: ['bank-account-form.component.css']
})

export class BankAccountFormComponent {
    @Input() customer: Customer;
    customerForm: FormGroup;
    nameChangeLog: string[] = [];

    constructor(private fb: FormBuilder,
                private customerService: CustomerService) {
        this.createForm();
        this.logNameChange();
    }

    ngOnChanges() {
        this.customerForm.reset({
            name: this.customer.FirstName,
            surname: this.customer.Surname,
            birthDate: this.customer.BirthDate,
            phone: this.customer.Phone,
            eMail: this.customer.EMail
        })
    }

    createForm() {
        this.customerForm = this.fb.group({
            name: ['', Validators.compose([Validators.required,
                Validators.minLength(4), this.forbiddenNameValidator(/admin/i)])],
            surname: ['', Validators.required],
            birthDate: '',
            phone: '',
            eMail: ''
        });
    }

    logNameChange() {
        const nameControl = this.customerForm.get('name');
        nameControl.valueChanges.forEach(
            (value: string) => this.nameChangeLog.push(value)
        );
    }

    onSubmit() {
        this.customer = this.prepareSaveCustomer();
        this.customerService.updateCustomer(this.customer);
        this.ngOnChanges();
    }

    prepareSaveCustomer(): Customer {
        const formModel = this.customerForm.value;

        // return new `Customer` object containing a combination of original customer value(s)
        // and deep copies of changed form model values
        const saveCustomer: Customer = {
            Id: this.customer.Id,
            FirstName: formModel.name as string,
            Surname: formModel.surname as string,
            BirthDate: formModel.birthDate as Date,
            Phone: formModel.phone as string,
            EMail: formModel.eMail as string
        };
        return saveCustomer;
    }

    revert() { this.ngOnChanges(); }

    forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
        return (control: AbstractControl): { [key: string]: any } => {
            const forbidden = nameRe.test(control.value);
            return forbidden ? { 'forbiddenName': { value: control.value } } : null;
        };
    }
}