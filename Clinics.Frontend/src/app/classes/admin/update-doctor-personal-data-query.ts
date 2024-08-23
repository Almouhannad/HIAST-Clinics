export class UpdateDoctorPersonalDataQuery {
    public id: number;
    public firstName: string;
    public middleName: string;
    public lastName: string;

    constructor(id: number, firstName: string, middleName: string, lastName:string) {
        this.id = id;
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
    }
}