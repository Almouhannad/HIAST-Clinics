export class UserData {
    public id: number;
    public userName!: string;
    public role!: string;
    public fullName?: string;

    constructor(id: number, userName: string, role: string, fullName?: string){
        this.id = id;
        this.userName = userName;
        this.role = role;
        this.fullName = fullName;
    }
}