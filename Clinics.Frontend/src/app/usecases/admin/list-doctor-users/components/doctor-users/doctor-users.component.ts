import { Component, OnInit } from '@angular/core';
import { DoctorUsersService } from '../../../services/doctor-users.service';
import { DoctorUser } from '../../classes/doctor-user';
import { ToastrService } from 'ngx-toastr';
import { GetAllDoctorUsersResult } from '../../classes/get-all-doctor-users-result';

@Component({
  selector: 'app-doctor-users',
  templateUrl: './doctor-users.component.html',
  styleUrl: './doctor-users.component.css'
})
export class DoctorUsersComponent implements OnInit {

  // #region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService, private toastrService:ToastrService) {}
  // #endregion

  // #region On init
  ngOnInit(): void {
    this.doctorUsersService.getDoctorUsers()
    .subscribe((getAllDoctorUsersResult: GetAllDoctorUsersResult) => {
      if (getAllDoctorUsersResult.status)
        this.doctorUsers = getAllDoctorUsersResult.doctorUsers!;
      else
        this.toastrService.error(getAllDoctorUsersResult.errorMessage!);
    })
  }
  // #endregion

  // #region Variables
  doctorUsers: DoctorUser[];
  // #endregion

}
