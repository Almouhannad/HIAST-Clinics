import { MedicineSearchResult } from "./medicine-search-result";

export class VisitMedicine {
    public id: number;
    public name: string;
    public form: 'شراب' | 'حبوب';
    public amount: number;
    public dosage: number;
    public number: number;

    constructor(id: number = 0, name: string = '',
        form: 'شراب' | 'حبوب' = 'حبوب', amount: number = 0, dosage: number = 0, number: number = 0) {
            
            this.id = id;
            this.name = name;
            this.form = form;
            this.amount = amount;
            this.dosage = dosage;
            this.number = number;
    }
}
