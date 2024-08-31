export class MedicineView {
    public name: string;
    public form: 'حبوب' | 'شراب'
    public amount: number;
    public dosage: number;
    public number: number;

    constructor(name: string = '', form: 'حبوب' | 'شراب' = 'حبوب',
        amount: number = 0, dosage: number = 0, number: number = 0
    ) {
        this.name = name;
        this.form = form;
        this.amount = amount;
        this.dosage = dosage;
        this.number = number;
    }
}
