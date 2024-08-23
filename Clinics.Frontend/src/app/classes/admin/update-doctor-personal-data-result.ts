export class UpdateDoctorPersonalDataResult {
    public status: boolean;
    public errorMessage: string | null = null;

    constructor (status: boolean, errorMessage: string | null = null)
    {
        this.status = status;
        this.errorMessage = errorMessage;
    }
}