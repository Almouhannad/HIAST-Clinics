export class LoginResult {
    constructor(status: boolean, errorMessage?: string)
    {
        this.status = status;
        this.errorMessage = errorMessage;
    }
    public status: Boolean;
    public errorMessage?: string;
}