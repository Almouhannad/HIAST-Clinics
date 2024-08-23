export class DoctorUser {
    constructor(id:number, userName: string, fullName: string) {
        this.id = id;
        this.userName = userName;
        this.fullName = fullName;
    }

    public id!: number;
    public userName!: string;
    public fullName!: string;
}