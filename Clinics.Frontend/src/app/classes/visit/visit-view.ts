import { MedicineView } from "../usecases/doctor-usecases/search-for-medicine/medicine-view";

export class VisitView {
    doctorName: string;
    diagnosis: string;
    date: Date;
    medicines: MedicineView[];

    constructor(doctorName: string = '', diagnosis: string = '', date: Date = new Date(Date.now()), medicines: MedicineView[] = []) {
        this.doctorName = doctorName;
        this.diagnosis = diagnosis;
        this.medicines = medicines;
    }
}
