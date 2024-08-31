import { Component, OnInit } from '@angular/core';
import { Phone } from '../../../../../classes/doctor/doctor';
import { DoctorsService } from '../../../../../services/doctors/doctors.service';
import { AuthenticationService } from '../../../../../services/authentication/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { ConstantMessages } from '../../../../../constants/messages';

@Component({
  selector: 'app-doctor-phones',
  templateUrl: './doctor-phones.component.html',
  styleUrl: './doctor-phones.component.css'
})
export class DoctorPhonesComponent implements OnInit{

  constructor(private doctorsService: DoctorsService,
    private authenticationService: AuthenticationService,
    private toastrService: ToastrService) {}


  userId: number = 0;
  ngOnInit(): void {
      this.setUserId();
      this.setPhones();
  }
  setUserId(): void {
    this.userId = this.authenticationService.getUserData()!.id;
  }
  setPhones(): void {
    this.doctorsService.getPhoneByUserId(this.userId)
    .subscribe(result => {
      if (result.status === false) {
        this.toastrService.error(ConstantMessages.ERROR);
      }
      else {
        this.phones = result.phones!;
      }
    })
  }

  phones: Phone[] = [];

}
