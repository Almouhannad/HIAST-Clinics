export class UpdateDoctorPersonalDataQuery {
    public firstName: string;
    public middleName: string;
    public lastName: string;

    constructor(firstName: string, middleName: string, lastName:string) {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
    }
}