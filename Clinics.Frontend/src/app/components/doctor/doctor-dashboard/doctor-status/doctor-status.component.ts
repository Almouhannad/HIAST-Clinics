import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../../services/authentication/authentication.service';
import { UserData } from '../../../../classes/authentication/user-data';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-doctor-status',
  templateUrl: './doctor-status.component.html',
  styleUrl: './doctor-status.component.css'
})
export class DoctorStatusComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
      
  }

  userData: UserData;
  setUserData(): void {
    this.userData = this.authenticationService.getUserData()!;
  }

  openModal(modal: any) {
    this.modalService.open(modal, {
      centered: true,
      size: 'md'
    });
  }
}
