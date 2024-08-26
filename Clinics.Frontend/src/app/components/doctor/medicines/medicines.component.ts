import { Component, Input } from '@angular/core';
import { MedicineView } from '../../../classes/medicine/medicine-view';

@Component({
  selector: 'app-medicines',
  templateUrl: './medicines.component.html',
  styleUrl: './medicines.component.css'
})
export class MedicinesComponent {

  @Input("medicines") medicines: MedicineView[] = [];
}
