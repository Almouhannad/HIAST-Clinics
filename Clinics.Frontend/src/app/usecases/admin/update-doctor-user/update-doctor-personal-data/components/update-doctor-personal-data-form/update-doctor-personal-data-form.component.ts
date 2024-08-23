import { Component, Input, ViewChild } from '@angular/core';
import { DoctorUsersService } from '../../../../services/doctor-users.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { UpdateDoctorPersonalDataQuery } from '../../classes/update-doctor-personal-data-query';

@Component({
  selector: 'app-update-doctor-personal-data-form',
  templateUrl: './update-doctor-personal-data-form.component.html',
  styleUrl: './update-doctor-personal-data-form.component.css'
})
export class UpdateDoctorPersonalDataFormComponent {

  //#region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService,
    private toastrService: ToastrService
  ) {}
  //#endregion

  // #region Inputs
  @Input("formModel") formModel: UpdateDoctorPersonalDataQuery = new UpdateDoctorPersonalDataQuery('','','');
  
  // #endregion
  
  //#region Variables
  @ViewChild("form") updateDoctorPseronalDataForm: NgForm;

  isFailure: boolean = false;
  errorMessage: string;
  //#endregion

  // #region On submut
  onSubmit(): void{

  }
  
  // #endregion
}
