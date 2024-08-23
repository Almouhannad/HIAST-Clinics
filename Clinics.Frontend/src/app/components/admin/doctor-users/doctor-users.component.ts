import { Component, OnInit } from '@angular/core';
import { DoctorUsersService } from '../../../services/admin/doctor-users.service';
import { DoctorUser } from '../../../classes/admin/doctor-user';
import { GetAllDoctorUsersResult } from '../../../classes/admin/get-all-doctor-users-result';

@Component({
  selector: 'app-doctor-users',
  templateUrl: './doctor-users.component.html',
  styleUrl: './doctor-users.component.css'
})
export class DoctorUsersComponent implements OnInit {

  // #region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService) {}
  // #endregion

  // #region On init
  ngOnInit(): void {
    this.doctorUsersService.getDoctorUsers()
    .subscribe((getAllDoctorUsersResult: GetAllDoctorUsersResult) => {
      if (getAllDoctorUsersResult.status)
        this.doctorUsers = getAllDoctorUsersResult.doctorUsers!;
      else
        console.error(getAllDoctorUsersResult.errorMessage!);
    })
  }
  // #endregion

  // #region Variables
  doctorUsers: DoctorUser[];
  // #endregion


}
