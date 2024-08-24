import { Component, Input, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-serial-number-pop-up',
  templateUrl: './employee-serial-number-pop-up.component.html',
  styleUrl: './employee-serial-number-pop-up.component.css'
})
export class EmployeeSerialNumberPopUpComponent {


  //#region CTOR DI
  constructor(private toastrService: ToastrService,
    private router: Router
  ) {}
  //#endregion

  //#region Inputs
  @Input("parentModal") parentModal : any;
  //#endregion  

  //#region Variables
  @ViewChild("form") form: NgForm;
  formModel: any = {serialNumber: 4};

  isFailure: boolean = false;
  errorMessage: string = '';
  //#endregion  

    // #region On submit
    onSubmit(): void {
      if (this.form.form.valid) {
        let id: number=5;
        this.router.navigateByUrl(`receptionist/employees/${id}`)
        this.parentModal.dismiss();
      }
      this.form.form.markAsPristine();
    }
    
    // #endregion


}
