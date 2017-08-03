import { Customer } from './customer.type';
import { Wallet } from './wallet.type';

export class Account {
    customer: Customer;
    walletList: Wallet[];
}