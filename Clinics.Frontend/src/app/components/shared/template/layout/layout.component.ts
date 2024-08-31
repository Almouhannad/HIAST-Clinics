import { Component, OnInit, ViewChild } from '@angular/core';
import { UserData } from '../../../../classes/authentication/user-data';
import { AuthenticationService } from '../../../../services/authentication/authentication.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DoctorNotificationsService } from '../../../../services/notifications/doctor-notifications/doctor-notifications.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit {

  //#region CTOR DI
  constructor(private authenticationService: AuthenticationService,
    private modalService: NgbModal,
    private doctorNotificationsService: DoctorNotificationsService
  ){}
  //#endregion

  //#region On init
  ngOnInit(): void {
    this.setUserData();
    this.listenToDoctorNotifications();
  }
  setUserData(): void {
    this.userData = this.authenticationService.getUserData();
  }
  //#endregion

  //#region Variables
  userData: UserData | null = null;
  //#endregion

  onUpdateUserData(): void {
    this.setUserData();
  }

  openModal(modal: any): void {
    this.modalService.open(modal, {
      centered: true,
      size: 'lg',
      backdrop: 'static',
      keyboard: false
    });
  }

  // #region Doctor notification 
  @ViewChild("doctorNotificationModal") doctorNotificationModal: any;
  doctorNotification : {
    patientId: Number,
    patientFullName: string,
    doctorId: Number,
    doctorUserId: Number
  }
  listenToDoctorNotifications(): void {
    this.doctorNotificationsService.startConnection();
    this.doctorNotificationsService.hubConnection.on('ReceiveNotification', (message) => {
      if(this.userData !== null) {
        if (message.doctorUserId == this.userData.id) {
          this.doctorNotification = message;
          this.openModal(this.doctorNotificationModal);
        }
      }
    });
  }
  
  // #endregion

}
