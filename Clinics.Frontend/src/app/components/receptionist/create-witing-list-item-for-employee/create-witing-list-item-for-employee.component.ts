import { Component, Input, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-witing-list-item-for-employee',
  templateUrl: './create-witing-list-item-for-employee.component.html',
  styleUrl: './create-witing-list-item-for-employee.component.css'
})
export class CreateWitingListItemForEmployeeComponent {

  // #region CTOR DI
  constructor(private toastrService: ToastrService,
    private router: Router
  ) { }

  // #endregion

  @ViewChild('form') form: NgForm;

  isFailure: boolean = false;
  errorMessage: string;

  @Input("formModel") formModel: any = { serialNumber: 5 };

  onSubmit(): void {
    if (this.form.valid) {
      
    }
  }


}
