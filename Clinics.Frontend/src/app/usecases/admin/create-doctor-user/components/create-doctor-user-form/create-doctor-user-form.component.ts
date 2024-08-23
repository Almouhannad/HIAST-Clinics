import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { DoctorUsersService } from '../../../services/doctor-users.service';
import { ToastrService } from 'ngx-toastr';
import { CreateDoctorUserCommand } from '../../classes/create-doctor-user-command';
import { NgForm } from '@angular/forms';
import { DoctorUser } from '../../../list-doctor-users/classes/doctor-user';

@Component({
  selector: 'app-create-doctor-user-form',
  templateUrl: './create-doctor-user-form.component.html',
  styleUrl: './create-doctor-user-form.component.css'
})
export class CreateDoctorUserFormComponent {
  //#region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService,
    private toastrService: ToastrService
  ) { }
  //#endregion

  //#region Inputs
  @Input("parentModal") parentModal: any;
  //#endregion

  //#region Outputs
  @Output("created") created: EventEmitter<DoctorUser> = new EventEmitter();
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
            }
            else {
              this.toastrService.success("تمت إضافة الطبيب بنجاح ✔");
              this.created.emit(
                new DoctorUser(
                  this.formModel.userName, `${this.formModel.firstName} ${this.formModel.middleName} ${this.formModel.lastName}`
                )
              )

            }
          }
        )
      this.loginForm.form.markAsPristine();

    }
  }
  // #endregion
}
