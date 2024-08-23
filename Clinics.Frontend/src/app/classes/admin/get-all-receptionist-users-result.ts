import { ReceptionistUser } from "./receptionist-user";


export class GetAllReceptionistUsersResult {
    public status: boolean;
    public errorMessage: string | null = null;
    public receptionistUsers: ReceptionistUser[] | null = null;

    constructor(status: boolean, errorMessage: string | null = null, receptionistUsers: ReceptionistUser[] | null = null)
    {
        this.status = status;
        this.errorMessage = errorMessage;
        this.receptionistUsers = receptionistUsers;
    }
}