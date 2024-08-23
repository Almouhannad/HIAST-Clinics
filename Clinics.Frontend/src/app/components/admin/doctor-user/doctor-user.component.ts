import { Component, Input } from '@angular/core';
import { DoctorUser } from '../../../classes/admin/doctor-user';

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
