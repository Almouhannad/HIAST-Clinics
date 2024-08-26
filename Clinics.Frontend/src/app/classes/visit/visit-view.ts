import { MedicineView } from "../medicine/medicine-view";

export class VisitView {
    doctorName: string;
    diagnosis: string;
    medicines: MedicineView[];

    constructor(doctorName: string = '', diagnosis: string = '', medicines: MedicineView[] = []) {
        this.doctorName = doctorName;
        this.diagnosis = diagnosis;
        this.medicines = medicines;
    }
}
