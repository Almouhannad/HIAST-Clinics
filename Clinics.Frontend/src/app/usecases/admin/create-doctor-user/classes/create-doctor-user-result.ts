export class CreateDoctorUserResult{

    constructor(status: boolean, errorMessage?:string){
        this.status = status;
        this.errorMessage = errorMessage;
    }

    public status: boolean;
    public errorMessage?: string;
}