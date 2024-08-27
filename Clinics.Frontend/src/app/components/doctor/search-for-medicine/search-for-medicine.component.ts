import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MedicinesService } from '../../../services/medicines/medicines.service';
import { MedicineSearchResult } from '../../../classes/medicine/medicine-search-result';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, filter, switchMap } from 'rxjs';
import { VisitMedicine } from '../../../classes/medicine/visit-medicine';

@Component({
  selector: 'app-search-for-medicine',
  templateUrl: './search-for-medicine.component.html',
  styleUrls: ['./search-for-medicine.component.css']
})
export class SearchForMedicineComponent implements OnInit {
  constructor(private medicinesService: MedicinesService,
    private toastrService: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {

    // Listen to input changes with delay
    this.prefix.valueChanges.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      filter(value => value.trim().length >= 2), // igonre less than 2 letters
      switchMap(value => this.medicinesService.getAll(value))
    )
    .subscribe(
      value => {
        if(value.status === false) {
          this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
          this.router.navigateByUrl('doctor/waitinglist');
        }
        else {
          this.medicines = value.medicines!;
        }
      }
    )
  }

  prefix: FormControl = new FormControl('');
  medicines: MedicineSearchResult[] = [];

  @Input("parentModal") parentModal: any;
  @Output("created") created: EventEmitter<VisitMedicine> = new EventEmitter();

  isSelected: boolean = false;
  selectedMedicine: MedicineSearchResult = new MedicineSearchResult();
  onSelect(index: number): void {
    this.isSelected = true;
    this.selectedMedicine = this.medicines.at(index)!;
  }

  number: number | null = null;

  onSave(): void {
    var result: VisitMedicine = new VisitMedicine(
      this.selectedMedicine.id, this.selectedMedicine.name, this.selectedMedicine.form,
      this.selectedMedicine.amount, this.selectedMedicine.dosage, this.number!);
    this.created.emit(result);
  }


}