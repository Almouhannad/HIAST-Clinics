import { Component, ViewChild } from '@angular/core';
import { DoctorUsersService } from '../../../services/doctor-users.service';
import { ToastrService } from 'ngx-toastr';
import { CreateDoctorUserCommand } from '../../classes/create-doctor-user-command';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ViewportScroller } from '@angular/common';

@Component({
  selector: 'app-create-doctor-user-form',
  templateUrl: './create-doctor-user-form.component.html',
  styleUrl: './create-doctor-user-form.component.css'
})
export class CreateDoctorUserFormComponent {

  //#region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService,
    private toastrService: ToastrService,
    private router: Router,
    private scroller: ViewportScroller
  ) { }
  //#endregion

  //#region Variables
  @ViewChild("createDoctorUserForm") loginForm: NgForm;
  formModel: CreateDoctorUserCommand = new CreateDoctorUserCommand();

  isFailure: boolean = false;
  errorMessage: string = '';
  //#endregion

  // #region on submit
  onSubmit(): void {
    console.table(this.loginForm);
    if (this.loginForm.valid) {
      this.isFailure = false;
      this.errorMessage = '';

      this.doctorUsersService.createDoctorUser(this.formModel)
        .subscribe(
          result => {
            if (result.status === false) {
              this.isFailure = true;
              this.errorMessage = result.errorMessage!;
              this.scroller.scrollToPosition([0,0])
            }
            else {
              this.toastrService.success("تم إضافة الطبيب بنجاح ✔");
              this.router.navigateByUrl('admin/doctors');
            }
          }
        )
      this.loginForm.form.markAsPristine();

    }
  }
  // #endregion
}
