export interface IContact {
    id?: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    phoneNumber: string;
    address: IAddress;
    contactFrequencyId: number;
}

interface IAddress {
    street: string;
    city: string;
    state: string;
    zip: string;
}