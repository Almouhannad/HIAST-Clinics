import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../../services/authentication/authentication.service';
import { UserData } from '../../../../classes/authentication/user-data';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DoctorsService } from '../../../../services/doctors/doctors.service';

@Component({
  selector: 'app-doctor-status',
  templateUrl: './doctor-status.component.html',
  styleUrl: './doctor-status.component.css'
})
export class DoctorStatusComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private doctorsService: DoctorsService
  ) {}

  ngOnInit(): void {  
    this.setUserData();
    this.setDoctorStatus();
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

  doctorStatus: string;
  setDoctorStatus(): void {
    this.doctorsService.getStatusByUserId(this.userData.id)
    .subscribe(result => {
      if (result.status === false) {
        this.toastr.error('حدثت مشكلة، يرجى إعادة المحاولة');
      }
      else {
        this.doctorStatus = result.doctorStatus!;
      }
    })
  }

  statuses: string[] = ['مشغول', 'متاح', 'لديه مريض'];

  onChangeStatus(): void {
    this.doctorsService.changeStatusByUserId(this.userData.id, this.doctorStatus)
    .subscribe(result => {
      if (result.status === false) {
        this.toastr.error('حدثت مشكلة، يرجى إعادة المحاولة');
      }
      else {
        this.toastr.success('تم تغيير الحالة بنجاح ✔')
      }
    })
  }
}
