import { Component, Input } from '@angular/core';
import { DoctorUser } from '../../../../../classes/usecases/admin-usecases/list-doctor-users/doctor-user';

@Component({
  selector: 'app-doctor-user',
  templateUrl: './doctor-user.component.html',
  styleUrl: './doctor-user.component.css'
})
export class DoctorUserComponent {

  // #region Inputs
  @Input("doctorUser") doctorUser: DoctorUser;
  // #endregion

}
