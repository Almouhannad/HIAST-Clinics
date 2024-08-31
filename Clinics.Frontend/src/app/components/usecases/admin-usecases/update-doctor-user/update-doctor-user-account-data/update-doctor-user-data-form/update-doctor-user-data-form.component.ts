import { Component, Input, ViewChild } from '@angular/core';
import { UpdateDoctorUserQuery } from '../../../../../../classes/usecases/admin-usecases/update-doctor-user/update-doctor-user-account-data/update-doctor-user-query';
import { DoctorUsersService } from '../../../../../../services/doctor-users/doctor-users.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ConstantMessages } from '../../../../../../constants/messages';

@Component({
  selector: 'app-update-doctor-user-data-form',
  templateUrl: './update-doctor-user-data-form.component.html',
  styleUrl: './update-doctor-user-data-form.component.css'
})
export class UpdateDoctorUserDataFormComponent {

  // #region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService,
    private toastrService: ToastrService,
    private router: Router
  ) {}
  
  // #endregion

  @ViewChild('form') form: NgForm;

  isFailure: boolean = false;
  errorMessage: string;

  @Input("formModel") formModel: UpdateDoctorUserQuery;

  onSubmit(): void {
    if (this.form.valid)
    {
      this.isFailure = false;
      this.doctorUsersService.updateDoctorUserData(this.formModel)
      .subscribe(
        result => {
          if (result.status === true) {
            this.toastrService.success(ConstantMessages.SUCCESS_EDIT);
            this.router.navigateByUrl('admin/doctors');
          }
          else {
            this.isFailure = true;
            this.errorMessage = result.errorMessage!;
            this.form.form.markAsPristine();
          }
        }
      )
    }
  }
}
