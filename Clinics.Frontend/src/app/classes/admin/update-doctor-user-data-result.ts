export class UpdateDoctorUserDataResult {
    status: boolean;
    errorMessage: string | null = null;

    constructor(status: boolean, errorMessage: string | null = null) {
        this.status = status;
        this.errorMessage = errorMessage;
    }
}