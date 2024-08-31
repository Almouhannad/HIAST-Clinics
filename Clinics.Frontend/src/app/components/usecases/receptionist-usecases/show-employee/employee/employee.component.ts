import { ViewportScroller } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeData } from '../../../../../classes/employee/employee-data';
import { EmployeesDataService } from '../../../../../services/employees/employees-data.service';
import { ConstantMessages } from '../../../../../constants/messages';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {

  //#region CTOR DI
  constructor(private toastrService: ToastrService,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private scroller: ViewportScroller,
    private employeesDataService: EmployeesDataService

  ) { }
  //#endregion

  ngOnInit(): void {
    this.getIdFromUrl();
  }

  getIdFromUrl(): void {
    this.activeRoute.params.subscribe((params: any) => {
      this.id = Number(params.id);
      if (isNaN(this.id)) {
        this.toastrService.error(ConstantMessages.ERROR);
        this.router.navigateByUrl('receptionist/waitinglist');
      }
      this.updateFormModel();
    });
  }

  updateFormModel(): void {
    this.employeesDataService.getById(this.id)
      .subscribe(result => {
        if (result.status === true) {
          this.formModel = result.employeeData!;
        }
        else {
          this.toastrService.error(ConstantMessages.ERROR);
          this.router.navigateByUrl('receptionist/waitinglist');
        }
      })
  }

  //#region Variables
  private id: number;

  @ViewChild("form") form: NgForm;
  formModel: EmployeeData = new EmployeeData();

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
      this.scroller.scrollToPosition([0, 0]);
    }
  }
  // #endregion

  getFullName(): string {
    return `${this.formModel.firstName} ${this.formModel.middleName} ${this.formModel.lastName}`
  }


  handleEdit(): void {
    this.isEditing = true;
    this.scroller.scrollToPosition([0, 0]);
  }

}
