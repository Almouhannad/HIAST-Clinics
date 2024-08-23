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
  isInvalid: boolean = false;
  errorMessage: string = '';

  isUserSectionOpen:boolean = true;
  isPersonalInfoSectionOpen:boolean = false;
  isOptionsSectionOpen:boolean = false;
  //#endregion

  // #region on submit
  onSubmit(): void {
    if (this.loginForm.valid) {
      this.isInvalid = false;
      this.isFailure = false;
      this.errorMessage = '';

      this.doctorUsersService.createDoctorUser(this.formModel)
        .subscribe(
          result => {
            if (result.status === false) {
              this.isFailure = true;
              this.errorMessage = result.errorMessage!;
              this.scroller.scrollToPosition([0,0]);
              this.loginForm.form.markAsPristine();

            }
            else {
              this.toastrService.success("تم إضافة الطبيب بنجاح ✔");
              this.router.navigateByUrl('admin/doctors');
            }
          }
        )
    }
    else {
      this.isInvalid = true;
      this.isOptionsSectionOpen = true;
      this.isPersonalInfoSectionOpen = true;
      this.isOptionsSectionOpen = true;
      this.loginForm.form.markAsPristine();
      this.scroller.scrollToPosition([0,0]);

    }
  }
  // #endregion
}
