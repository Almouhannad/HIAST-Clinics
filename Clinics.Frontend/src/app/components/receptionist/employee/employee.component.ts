import { ViewportScroller } from '@angular/common';
import { Component, numberAttribute, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {

  //#region CTOR DI
  constructor(private toastrService: ToastrService,
    private router: Router,
    private scroller: ViewportScroller
  ) { }
  //#endregion

  //#region Variables
  @ViewChild("form") form: NgForm;
  formModel: any = {
    "firstName": "المهند",
    "middleName": "ياسر",
    "lastName": "حافظ",
    "dateOfBirth": "2002-06-09",
    "gender": "ذكر",
    "serialNumber": "992022",
    "centerStatus": "مباشر عمله",
  }

  isFailure: boolean = false;
  isInvalid: boolean = false;
  errorMessage: string = '';

  isEditing: boolean = false;
  firstOpen: boolean = true;

  isPersonal: boolean = false;
  isAdditional: boolean = true;
  isWork: boolean = false;
  isOptions: boolean = false;
  //#endregion  


  // #region on submit
  onSubmit(): void {
    if (this.form.valid) {
      
      this.isInvalid = false;
      this.isFailure = false;
      this.errorMessage = '';
    }

    else {
      this.isInvalid = true;
      // this.isPersonal = true;
      // this.isAdditional = true;
      // this.isWork = true;
      // this.isOptions = true;
      this.form.form.markAsPristine();
      this.scroller.scrollToPosition([0,0]);
    }
  }
  // #endregion

  getFullName(): string {
    return `${this.formModel.firstName} ${this.formModel.middleName} ${this.formModel.lastName}`
  }


  handleEdit(): void {
    this.isEditing = true;
    this.scroller.scrollToPosition([0,0]);
  }
  
}
