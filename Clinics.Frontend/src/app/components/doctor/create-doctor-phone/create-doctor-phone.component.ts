import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DoctorPhone } from '../../../classes/doctor/phones/doctor-phone';
import { DoctorsService } from '../../../services/doctors/doctors.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { ViewportScroller } from '@angular/common';
import { ConstantMessages } from '../../../constants/messages';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-doctor-phone',
  templateUrl: './create-doctor-phone.component.html',
  styleUrl: './create-doctor-phone.component.css'
})
export class CreateDoctorPhoneComponent implements OnInit{

  constructor(private doctorsService: DoctorsService,
    private authenticationService: AuthenticationService,
    private toastrService: ToastrService,
    private viewportScroller: ViewportScroller,
    private router: Router
  ) {}

  userId: number = 0;
  ngOnInit(): void {
      this.setUserId();
  }
  setUserId(): void {
    this.userId = this.authenticationService.getUserData()!.id;
  }

// #region server-side errors variables
  isFailure: boolean = false;
  errorMessage: string = '';
// #endregion


// #region Submit form
  @ViewChild("form") form: NgForm;
  formModel: DoctorPhone = new DoctorPhone();


  onSubmit(): void {
    this.isFailure = false;
    this.errorMessage = '';
    this.doctorsService.addPhoneByUserId(this.userId, this.formModel)
    .subscribe(result => {
      if (result.status === false) {
        this.isFailure = true;
        this.errorMessage = result.errorMessage!;
        this.viewportScroller.scrollToPosition([0,0]);
      }
      else {
        this.toastrService.success(ConstantMessages.SUCCESS_ADD);
        this.router.navigateByUrl('doctor/phones');
      }
    })
  }

// #endregion

}
