import { Component, Input, OnInit } from '@angular/core';
import { ReceptionistUser } from '../../../../../classes/usecases/admin-usecases/list-receptionist-users/receptionist-user';

@Component({
  selector: 'app-receptionist-user',
  templateUrl: './receptionist-user.component.html',
  styleUrl: './receptionist-user.component.css'
})
export class ReceptionistUserComponent{

  @Input("receptionistUser") receptionistUser: ReceptionistUser = new ReceptionistUser(0,'','');
}
