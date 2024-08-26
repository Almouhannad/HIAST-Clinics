import { Component, Input, NgModuleFactory } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-is-coming-notification',
  templateUrl: './patient-is-coming-notification.component.html',
  styleUrl: './patient-is-coming-notification.component.css'
})
export class PatientIsComingNotificationComponent {

  constructor(private router: Router) {}

  @Input("parentModal") parentModal: any;

  @Input("notification") notification : {
    patientId: Number,
    patientFullName: string,
    doctorId: Number,
    doctorUserId: Number
  };

  onReceive(): void {
    this.router.navigateByUrl(`doctor/visits/create/${this.notification.patientId}`);
    this.parentModal.dismiss();
  }


}
