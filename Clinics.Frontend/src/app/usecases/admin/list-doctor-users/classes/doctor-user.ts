export class DoctorUser {
    constructor(userName: string, fullName: string) {
        this.userName = userName;
        this.fullName = fullName;
    }

    public userName!: string;
    public fullName!: string;
}