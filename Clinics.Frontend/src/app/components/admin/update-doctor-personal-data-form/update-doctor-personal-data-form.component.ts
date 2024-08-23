import { Component, Input, ViewChild } from '@angular/core';
import { DoctorUsersService } from '../../../services/admin/doctor-users.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { UpdateDoctorPersonalDataQuery } from '../../../classes/admin/update-doctor-personal-data-query';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-doctor-personal-data-form',
  templateUrl: './update-doctor-personal-data-form.component.html',
  styleUrl: './update-doctor-personal-data-form.component.css'
})
export class UpdateDoctorPersonalDataFormComponent {

  //#region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService,
    private toastrService: ToastrService,
    private router: Router
  ) {}
  //#endregion

  // #region Inputs
  @Input("formModel") formModel: UpdateDoctorPersonalDataQuery = new UpdateDoctorPersonalDataQuery(1,'','','');
  
  // #endregion
  
  //#region Variables
  @ViewChild("form") form: NgForm;

  isFailure: boolean = false;
  errorMessage: string;
  //#endregion

  // #region On submut
  onSubmit(): void{
    this.isFailure = false;
    if(this.form.valid)
    {
      this.doctorUsersService.updateDoctorPersonalInfo(this.formModel)
      .subscribe(
        result => {
          if (result.status === true)
          {
            this.toastrService.success('تم تعديل البيانات بنجاح');
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
  
  // #endregion
}
