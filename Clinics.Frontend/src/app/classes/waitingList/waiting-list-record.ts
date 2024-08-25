export class WaitingListRecord {
    public id: number = 0;
    public patientId: number = 0;
    public fullName: string = '';
    public isEmployee: boolean = true;
    public arrivalTime: Date = new Date(Date.now());

    constructor(id: number,
        patientId: number,
        fullName: string,
        isEmployee: boolean,
        arrivalTime: Date) {
            this.id = id;
            this.patientId = patientId;
            this.fullName = fullName;
            this.isEmployee = isEmployee;
            this.arrivalTime = arrivalTime;
    }
}

export class WaitingListRecordTypes {
    public static readonly Employee: string = "موظف";
    public static readonly FamilyMember: string = "أفراد عائلة";
}