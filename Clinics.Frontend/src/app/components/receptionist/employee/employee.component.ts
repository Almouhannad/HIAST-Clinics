import { ViewportScroller } from '@angular/common';
import { AfterViewInit, Component, numberAttribute, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeData } from '../../../classes/employeeData/employee-data';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';

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
    this.updateFormModel();
  }

  getIdFromUrl(): void {

    this.id = Number(this.activeRoute.snapshot.paramMap.get('id'));
    if (isNaN(this.id)) {
      this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
      this.router.navigateByUrl('receptionist/waitinglist');
    }

  }

  updateFormModel(): void {
    this.employeesDataService.getById(this.id)
      .subscribe(result => {
        if (result.status === true) {
          this.formModel = result.employeeData!;
        }
        else {
          this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
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
