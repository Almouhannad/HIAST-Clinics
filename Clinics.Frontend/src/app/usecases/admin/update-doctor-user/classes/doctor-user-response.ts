export class DoctorUserResponse {
    public id!: number;
    public userName!: string;
    public firstName!: string;
    public middleName!: string;
    public lastName!: string;

    constructor() {
        this.userName='';
        this.firstName='';
        this.middleName='';
        this.lastName='';
    }


}