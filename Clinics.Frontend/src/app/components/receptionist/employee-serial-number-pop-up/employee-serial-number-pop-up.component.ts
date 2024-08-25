import { Component, Input, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';

@Component({
  selector: 'app-employee-serial-number-pop-up',
  templateUrl: './employee-serial-number-pop-up.component.html',
  styleUrl: './employee-serial-number-pop-up.component.css'
})
export class EmployeeSerialNumberPopUpComponent {


  //#region CTOR DI
  constructor(private router: Router,
    private employeesDataService: EmployeesDataService
  ) {}
  //#endregion

  //#region Inputs
  @Input("parentModal") parentModal : any;
  //#endregion  

  //#region Variables
  @ViewChild("form") form: NgForm;
  formModel: any = {serialNumber: ''};

  isFailure: boolean = false;
  errorMessage: string = '';
  //#endregion  

    // #region On submit
    onSubmit(): void {
      this.isFailure = false;
      this.errorMessage = '';
      if (this.form.form.valid) {
        this.employeesDataService.getBySerialNumber(this.formModel.serialNumber)
        .subscribe(result => {
          if (result.status === true) {
            const id = result.employeeData!.id;
            this.parentModal.dismiss();
            this.router.navigateByUrl(`receptionist/employees/${id}`);
          }
          else {
            this.isFailure = true;
            this.errorMessage = result.errorMessage!;
            this.form.form.markAsPristine();
          }
        })
      }
      
    }
    
    // #endregion


}
