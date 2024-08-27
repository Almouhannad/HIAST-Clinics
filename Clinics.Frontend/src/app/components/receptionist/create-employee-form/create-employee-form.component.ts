import { ViewportScroller } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeData } from '../../../classes/employeeData/employee-data';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';
import { ConstantMessages } from '../../../constants/messages';

@Component({
  selector: 'app-create-employee-form',
  templateUrl: './create-employee-form.component.html',
  styleUrl: './create-employee-form.component.css'
})
export class CreateEmployeeFormComponent {
  //#region CTOR DI
  constructor(private toastrService: ToastrService,
    private router: Router,
    private scroller: ViewportScroller,
    private employeesDataService: EmployeesDataService
  ) { }
  //#endregion

  //#region Variables
  @ViewChild("form") form: NgForm;
  formModel: EmployeeData = new EmployeeData();

  isFailure: boolean = false;
  isInvalid: boolean = false;
  errorMessage: string = '';

  isPersonal: boolean = true;
  isAdditional: boolean = false;
  isWork: boolean = false;
  isOptions: boolean = false;
  //#endregion


  // #region on submit
  onSubmit(): void {
    if (this.form.valid) {
      this.isInvalid = false;
      this.isFailure = false;
      this.errorMessage = '';

      this.employeesDataService.create(this.formModel)
      .subscribe(result => {
        if (result.status === true) {
          this.toastrService.success(ConstantMessages.SUCCESS_ADD_EMPLOYEE);
          this.router.navigateByUrl(`receptionist/employees/${result.id!}`);
        }
        else {
          this.isFailure = true;
          this.errorMessage = result.errorMessage!;
          this.isPersonal = true;
          this.isAdditional = true;
          this.isWork = true;
          this.isOptions = true;
          this.form.form.markAsPristine();
          this.scroller.scrollToPosition([0,0]);

        }
      })
    }
    else {
      this.isInvalid = true;
      this.isPersonal = true;
      this.isAdditional = true;
      this.isWork = true;
      this.isOptions = true;
      this.form.form.markAsPristine();
      this.scroller.scrollToPosition([0,0]);
    }
  }
  // #endregion
}
