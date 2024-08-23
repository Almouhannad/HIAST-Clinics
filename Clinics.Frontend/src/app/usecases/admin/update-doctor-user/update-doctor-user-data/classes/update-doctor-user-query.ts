export class updateDoctorUserQuery {
    public id: number;
    public userName: string;
    public password: string | null = null;

    constructor(id:number, userName: string, password: string | null = null) {
        this.id = id;
        this.userName = userName;
        this.password = password;
    }
}