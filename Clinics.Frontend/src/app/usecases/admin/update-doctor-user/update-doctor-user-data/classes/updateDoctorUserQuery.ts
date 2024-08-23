export class updateDoctorUserQuery {
    public userName: string;
    public password: string | null = null;

    constructor(userName: string, password: string | null = null) {
        this.userName = userName;
        this.password = password;
    }
}