import { Component, Input, OnInit } from '@angular/core';
import { DoctorsService } from '../../../services/doctors/doctors.service';
import { Doctor } from '../../../classes/doctor/doctor';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrl: './doctors.component.css'
})
export class DoctorsComponent implements OnInit {

  constructor(private doctorsService: DoctorsService,
    private toasreService: ToastrService
  ) {}

  ngOnInit(): void {
      this.updateDoctors();
  }

  updateDoctors(): void {
    this.doctorsService.getAll()
    .subscribe(result => {
      if (result === null) {
        this.toasreService.error('حدثت مشكلة، يرجى إعادة المحاولة');
      }
      else this.doctors = result;
    })
  }

  doctors: Doctor[] = []
}
