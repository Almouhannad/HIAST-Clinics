export class EmployeeData {
    public id: number;
    public firstName: string;
    public middleName: string;
    public lastName: string;
    public dateOfBirth: Date;
    public gender: 'ذكر' | 'أنثى' | null;
    public serialNumber: string;
    public centerStatus: string;

    constructor(
        id: number = 0,
        firstName: string = '',
        middleName: string = '',
        lastName: string = '',
        dateOfBirth: Date = new Date(Date.now()),
        gender: 'ذكر' | 'أنثى' | null = null ,
        serialNumber: string = '',
        centerStatus: string = ''
    ) {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        this.serialNumber = serialNumber;
        this.centerStatus = centerStatus;
    }
}
