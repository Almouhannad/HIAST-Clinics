import { DoctorUser } from "./doctor-user";

export class GetAllDoctorUsersResult {

    constructor(status: boolean, errorMessage?: string, doctorUsers?: DoctorUser[])
    {
        this.status = status;
        this.errorMessage = errorMessage;
        this.doctorUsers = doctorUsers;
    }
    public status!: boolean;
    public errorMessage?: string;
    public doctorUsers?: DoctorUser[];
    
}