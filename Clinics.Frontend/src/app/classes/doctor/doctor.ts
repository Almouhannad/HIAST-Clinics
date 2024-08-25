export class Doctor {
    public fullName: string;
    public status: string;
    public phones: Phone [];

    constructor(fullName: string = '', status: string = '', phones: Phone[] = [])
    {
        this.fullName = fullName;
        this.status = status;
        this.phones = phones;
    }
}

export class Phone {
    public name: string;
    public phone: string;

    constructor(name: string = '', phone: string = '') {
        this.name = name;
        this.phone = phone;
    }
}

export class DoctorStatuses {
    public static readonly Online = 'متاح';
    public static readonly Busy = 'مشغول';
    public static readonly InWork = 'لديه مريض';
}