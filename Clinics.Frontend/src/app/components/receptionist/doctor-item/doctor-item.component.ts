import { Component, Input } from '@angular/core';
import { Doctor, DoctorStatuses } from '../../../classes/doctor/doctor';

@Component({
  selector: 'app-doctor-item',
  templateUrl: './doctor-item.component.html',
  styleUrl: './doctor-item.component.css'
})
export class DoctorItemComponent {

  @Input("doctor") doctor: Doctor = new Doctor();

  statuses = {
    Online: DoctorStatuses.Online,
    Busy: DoctorStatuses.Busy,
    InWork: DoctorStatuses.InWork
  }
}
