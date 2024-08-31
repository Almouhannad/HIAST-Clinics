import { Component, Input } from '@angular/core';
import { DoctorPhone } from '../../../classes/doctor/phones/doctor-phone';

@Component({
  selector: 'app-doctor-phone',
  templateUrl: './doctor-phone.component.html',
  styleUrl: './doctor-phone.component.css'
})
export class DoctorPhoneComponent {

  @Input("phone") phone: DoctorPhone = new DoctorPhone();

}
